#!/usr/bin/env python3
"""Extract key->value from .NET satellite .resources blobs embedded in Resources.resources.dll.
Validated on fa-IR satellite: hash fn = h*33 ^ c (UTF-16 chars), names in UTF-16LE with byte-length prefix,
each name entry followed by 4-byte data offset (relative to data section start).
"""
import struct
import sys

def h33(name):
    h = 5381
    for ch in name:
        h = (((h << 5) + h) ^ ord(ch)) & 0xFFFFFFFF
    return h

def signed(x):
    return x - 0x100000000 if x >= 0x80000000 else x

def read7bit(data, pos):
    r = 0; s = 0
    while True:
        b = data[pos]; pos += 1
        r |= (b & 0x7F) << s
        if not (b & 0x80): break
        s += 7
    return r, pos

class Blob:
    def __init__(self, data, off):
        self.data = data
        hdrsize = struct.unpack('<i', data[off+8:off+12])[0]
        pos = off + 12 + hdrsize
        setver, self.num, numTypes = struct.unpack('<iii', data[pos:pos+12])
        pos += 12
        # skip type names if any
        for _ in range(numTypes):
            nlen, pos = read7bit(data, pos)
            pos += nlen
        # skip PAD padding: literal run of 'PAD' chars (e.g. "PADPADP")
        run_start = pos
        while chr(data[pos]) in ('P', 'A', 'D'):
            pos += 1
        # the padding only contains P/A/D chars; a hash starting with such bytes is astronomically unlikely
        if pos - run_start < 3:
            pos = run_start  # not padding — restore
        self.hash_start = pos
        self.hashes = [struct.unpack('<I', data[pos+i*4:pos+i*4+4])[0] for i in range(self.num)]
        after_hashes = pos + self.num*4
        self.name_offsets = [struct.unpack('<i', data[after_hashes+i*4:after_hashes+i*4+4])[0] for i in range(self.num)]
        # names_base = after hashes + N offsets + 4 bytes (unknown field / version+pad)
        self.names_base = after_hashes + self.num*4 + 4
        # read name entries sequentially in buffer order
        self.entries = []  # (name, data_offset)
        p = self.names_base
        for _ in range(self.num):
            # name byte-length is 7-bit encoded (0x80 0x01 = 128)
            ln, p = read7bit(data, p)
            name = data[p:p+ln].decode('utf-16-le', errors='replace'); p += ln
            doff = struct.unpack('<i', data[p:p+4])[0]; p += 4
            self.entries.append((name, doff))
        self.data_base = p
        # verify: entry data offsets < data section size
        # compute data end: max offset + entry size (we don't know sizes; read on demand)

    def get(self, key):
        h = h33(key)
        if h not in self.hashes:
            return None
        # find index in hash array -> name offset -> entry
        idx = self.hashes.index(h)
        npos = self.name_offsets[idx]
        # walk entries to find the one at names_base+npos
        target = None
        p = self.names_base
        for name, doff in self.entries:
            if p == self.names_base + npos:
                target = (name, doff); break
            # advance: prefix(1 or 5) + name + 4
            pass
        # simpler: locate entry by position
        target = None
        p = self.names_base
        for name, doff in self.entries:
            if p - self.names_base == npos:
                target = (name, doff); break
            ln = len(name)*2
            ln += 5 if ln >= 0xFF else 1
            p += ln + 4
        if not target:
            # fallback: match by name
            for name, doff in self.entries:
                if name == key:
                    target = (name, doff); break
        if not target:
            return None
        name, doff = target
        d = self.data[self.data_base + doff:]
        tc = d[0]
        if tc == 0x01:  # string
            vlen, q = read7bit(d, 1)
            return d[q:q+vlen].decode('utf-8', errors='replace')
        return f'<typecode {tc}>'

def load_blobs(path):
    data = open(path, 'rb').read()
    import re
    offs = [m.start() for m in re.finditer(re.escape(b'\xce\xca\xef\xbe'), data)]
    blobs = []
    for off in offs:
        try:
            blobs.append(Blob(data, off))
        except Exception as e:
            print(f'blob at {off} failed: {e}', file=sys.stderr)
    return blobs

if __name__ == '__main__':
    path = sys.argv[1]
    blobs = load_blobs(path)
    keys = sys.argv[2:]
    for b in blobs:
        sample = [n for n, _ in b.entries[:2]]
        print(f'--- blob num={b.num} sample={sample}')
        for k in keys:
            v = b.get(k)
            if v is not None:
                print(f'{k} = {v!r}')
