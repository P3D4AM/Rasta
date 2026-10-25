"use client";

import { useEffect, useMemo, useState } from "react";
import {
  Search, Plus, Boxes, Warehouse as WarehouseIcon, ArrowLeft,
  FileClock, PackageX, TrendingDown, AlertTriangle, Banknote,
} from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import {
  Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle,
} from "@/components/ui/dialog";
import {
  Select, SelectContent, SelectItem, SelectTrigger, SelectValue,
} from "@/components/ui/select";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { useToast } from "@/hooks/use-toast";
import { PageHeader } from "@/components/rasta/page-header";
import { DataTable, type Column } from "@/components/rasta/data-table";
import { StatusBadge } from "@/components/rasta/status-badge";
import { useList, api } from "@/hooks/use-list";
import { formatMoney } from "@/lib/format";
import { formatJalaliDateTime, toPersianDigits } from "@/lib/jalali";
import {
  MOVEMENT_TYPES, MOVEMENT_TYPE_LABELS, MOVEMENT_REF_LABELS, LOW_STOCK_THRESHOLD,
} from "@/lib/constants";

type LevelRow = {
  id: string; quantity: number;
  product: { id: string; name: string; code: string | null; unit: string; cost: number | null; price: number };
  warehouse: { id: string; name: string };
};

type MovementRow = {
  id: string; type: string; quantity: number; note: string | null;
  refType: string | null; movedAt: string;
  product: { name: string; code: string | null; unit: string };
  fromWarehouse: { name: string } | null;
  toWarehouse: { name: string } | null;
  user: { firstName: string; lastName: string } | null;
};

type Summary = { itemCount: number; totalValue: number; lowCount: number; outCount: number };
type ProductOption = { id: string; name: string; code: string | null; unit: string; cost: number | null; price: number };
type WarehouseOption = { id: string; name: string; isDefault: boolean };

const emptyMovement = {
  type: "IN" as string,
  productId: "",
  fromWarehouseId: "",
  toWarehouseId: "",
  quantity: "",
  unitCost: "",
  note: "",
};

export default function InventoryPage() {
  const { toast } = useToast();
  // ── levels tab state ──
  const [page, setPage] = useState(1);
  const [searchText, setSearchText] = useState("");
  const [search, setSearch] = useState("");
  const [warehouseFilter, setWarehouseFilter] = useState("ALL");
  const [availability, setAvailability] = useState("ALL");
  const [summary, setSummary] = useState<Summary>({ itemCount: 0, totalValue: 0, lowCount: 0, outCount: 0 });

  // ── movements tab state ──
  const [mPage, setMPage] = useState(1);
  const [mSearchText, setMSearchText] = useState("");
  const [mSearch, setMSearch] = useState("");
  const [mType, setMType] = useState("ALL");
  const [mWarehouse, setMWarehouse] = useState("ALL");

  // ── shared ──
  const [warehouses, setWarehouses] = useState<WarehouseOption[]>([]);
  const [products, setProducts] = useState<ProductOption[]>([]);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [form, setForm] = useState(emptyMovement);
  const [saving, setSaving] = useState(false);
  const [currentQty, setCurrentQty] = useState<number | null>(null);

  // ── stock card dialog ──
  const [cardProduct, setCardProduct] = useState<{ id: string; name: string; unit: string } | null>(null);
  const [cardRows, setCardRows] = useState<MovementRow[]>([]);
  const [cardLoading, setCardLoading] = useState(false);

  const levelsUrl = useMemo(
    () =>
      `/api/inventory?page=${page}&search=${encodeURIComponent(search)}&warehouseId=${warehouseFilter}&availability=${availability}`,
    [page, search, warehouseFilter, availability]
  );
  const { rows, total, loading, refresh } = useList<LevelRow>(levelsUrl);

  const movementsUrl = useMemo(
    () =>
      `/api/stock-movements?page=${mPage}&search=${encodeURIComponent(mSearch)}&type=${mType}&warehouseId=${mWarehouse}`,
    [mPage, mSearch, mType, mWarehouse]
  );
  const mList = useList<MovementRow>(movementsUrl);

  // summary follows the same filters as the levels tab
  useEffect(() => {
    fetch(
      `/api/inventory?page=1&pageSize=1&search=${encodeURIComponent(search)}&warehouseId=${warehouseFilter}&availability=${availability}`
    )
      .then((r) => r.json())
      .then((d) => setSummary(d.summary ?? { itemCount: 0, totalValue: 0, lowCount: 0, outCount: 0 }))
      .catch(() => {});
  }, [search, warehouseFilter, availability, rows]);

  // warehouses for filters + movement dialog
  useEffect(() => {
    fetch("/api/warehouses")
      .then((r) => r.json())
      .then((d) =>
        setWarehouses(
          (d.rows ?? []).filter((x: WarehouseOption & { isActive: boolean }) => x.isActive)
        )
      )
      .catch(() => {});
  }, []);

  async function openDialog() {
    const [wRes, pRes] = await Promise.all([
      fetch("/api/warehouses"),
      fetch("/api/products?active=1&pageSize=200"),
    ]);
    const [w, p] = await Promise.all([wRes.json(), pRes.json()]);
    setWarehouses((w.rows ?? []).filter((x: WarehouseOption & { isActive: boolean }) => x.isActive));
    setProducts(p.rows ?? []);
    setForm(emptyMovement);
    setCurrentQty(null);
    setDialogOpen(true);
  }
  async function refreshAll() {
    refresh();
    mList.refresh();
  }

  // for ADJUST: show current stock of selected product+warehouse
  async function probeCurrentQty(productId: string, warehouseId: string) {
    setCurrentQty(null);
    if (!productId || !warehouseId) return;
    try {
      const d = await api<{ rows: { quantity: number }[] }>(
        `/api/inventory?productId=${productId}&warehouseId=${warehouseId}&pageSize=5`
      );
      setCurrentQty(d.rows?.[0]?.quantity ?? 0);
    } catch {
      setCurrentQty(null);
    }
  }

  async function save() {
    if (!form.productId) return toast({ title: "انتخاب کالا الزامی است.", variant: "destructive" });
    const qty = Number(form.quantity);
    if (!Number.isFinite(qty) || form.quantity === "") {
      return toast({ title: "تعداد را وارد کنید.", variant: "destructive" });
    }
    if (form.type === "ADJUST" && qty === 0) {
      return toast({ title: "مقدار اصلاح نمی‌تواند صفر باشد.", variant: "destructive" });
    }
    setSaving(true);
    try {
      await api("/api/stock-movements", {
        method: "POST",
        body: {
          type: form.type,
          productId: form.productId,
          fromWarehouseId: form.fromWarehouseId || null,
          toWarehouseId: form.toWarehouseId || null,
          quantity: qty,
          unitCost: form.unitCost === "" ? null : Number(form.unitCost),
          note: form.note,
        },
      });
      toast({ title: "گردش موجودی ثبت شد." });
      setDialogOpen(false);
      refreshAll();
    } catch (e) {
      toast({ title: "خطا در ثبت گردش", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function openStockCard(row: LevelRow) {
    setCardProduct({ id: row.product.id, name: row.product.name, unit: row.product.unit });
    setCardRows([]);
    setCardLoading(true);
    try {
      const d = await api<{ rows: MovementRow[] }>(`/api/stock-movements?productId=${row.product.id}&pageSize=50`);
      setCardRows(d.rows ?? []);
    } catch {
      setCardRows([]);
    } finally {
      setCardLoading(false);
    }
  }

  const levelColumns: Column<LevelRow>[] = [
    {
      key: "product",
      header: "کالا",
      render: (l) => (
        <div>
          <p className="font-bold">{l.product.name}</p>
          {l.product.code && <p className="text-xs text-muted-foreground" dir="ltr">{l.product.code}</p>}
        </div>
      ),
    },
    {
      key: "warehouse",
      header: "انبار",
      render: (l) => (
        <span className="inline-flex items-center gap-1 text-sm text-muted-foreground">
          <WarehouseIcon className="w-3.5 h-3.5" />
          {l.warehouse.name}
        </span>
      ),
    },
    {
      key: "quantity",
      header: "موجودی",
      render: (l) => {
        const q = l.quantity;
        const cls = q <= 0 ? "text-rose-600" : q < LOW_STOCK_THRESHOLD ? "text-amber-600" : "text-emerald-700";
        return (
          <span className={`font-bold ${cls}`}>
            {toPersianDigits(q)} {l.product.unit}
            {q <= 0 ? " (ناموجود)" : q < LOW_STOCK_THRESHOLD ? " (رو به اتمام)" : ""}
          </span>
        );
      },
    },
    {
      key: "value",
      header: "ارزش موجودی (ریال)",
      render: (l) => (
        <span className="text-muted-foreground">
          {formatMoney(l.quantity * (l.product.cost ?? l.product.price))}
        </span>
      ),
    },
    {
      key: "actions",
      header: "",
      className: "w-20 text-end",
      render: (l) => (
        <Button variant="outline" size="sm" className="h-8 gap-1 text-xs" onClick={() => openStockCard(l)}>
          <FileClock className="w-3.5 h-3.5" />
          کارت کالا
        </Button>
      ),
    },
  ];

  const movementColumns: Column<MovementRow>[] = [
    {
      key: "movedAt",
      header: "تاریخ",
      render: (m) => <span className="text-xs text-muted-foreground">{formatJalaliDateTime(m.movedAt)}</span>,
    },
    {
      key: "type",
      header: "نوع",
      render: (m) => <StatusBadge value={m.type} label={MOVEMENT_TYPE_LABELS[m.type] ?? m.type} />,
    },
    { key: "product", header: "کالا", render: (m) => <span className="font-bold text-sm">{m.product.name}</span> },
    {
      key: "route",
      header: "مسیر",
      render: (m) => (
        <span className="inline-flex items-center gap-1.5 text-sm text-muted-foreground" dir="rtl">
          {m.fromWarehouse && <span>{m.fromWarehouse.name}</span>}
          {(m.fromWarehouse || m.toWarehouse) && <ArrowLeft className="w-3.5 h-3.5" />}
          {m.toWarehouse && <span>{m.toWarehouse.name}</span>}
          {!m.fromWarehouse && !m.toWarehouse && <span>—</span>}
        </span>
      ),
    },
    {
      key: "quantity",
      header: "تعداد",
      render: (m) => (
        <span className={`font-bold text-sm ${m.type === "IN" ? "text-emerald-700" : m.type === "OUT" ? "text-rose-600" : ""}`}>
          {m.type === "OUT" ? "−" : m.type === "ADJUST" && m.quantity < 0 ? "−" : "+"}
          {toPersianDigits(Math.abs(m.quantity))} {m.product.unit}
        </span>
      ),
    },
    {
      key: "ref",
      header: "مرجع",
      render: (m) => (
        <span className="text-xs text-muted-foreground">{m.refType ? MOVEMENT_REF_LABELS[m.refType] ?? m.refType : "—"}</span>
      ),
    },
    {
      key: "user",
      header: "کاربر",
      render: (m) => (
        <span className="text-xs text-muted-foreground">
          {m.user ? `${m.user.firstName} ${m.user.lastName}` : "—"}
        </span>
      ),
    },
  ];

  const cards = [
    { label: "اقلام دارای موجودی", value: toPersianDigits(summary.itemCount), icon: Boxes, color: "text-emerald-600 bg-emerald-50" },
    { label: "ارزش کل موجودی (ریال)", value: formatMoney(summary.totalValue), icon: Banknote, color: "text-sky-600 bg-sky-50" },
    { label: `رو به اتمام (کمتر از ${toPersianDigits(LOW_STOCK_THRESHOLD)})`, value: toPersianDigits(summary.lowCount), icon: AlertTriangle, color: "text-amber-600 bg-amber-50" },
    { label: "ناموجود", value: toPersianDigits(summary.outCount), icon: PackageX, color: "text-rose-600 bg-rose-50" },
  ];

  return (
    <div>
      <PageHeader
        title="موجودی و گردش کالا"
        subtitle="کنترل انبار، رسید و حواله"
        actions={
          <Button onClick={openDialog}>
            <Plus className="w-4 h-4 me-1" />
            ثبت گردش موجودی
          </Button>
        }
      />

      <div className="grid grid-cols-2 lg:grid-cols-4 gap-3 mb-5">
        {cards.map((c) => (
          <div key={c.label} className="rounded-xl border bg-card p-4 flex items-center gap-3">
            <div className={`w-10 h-10 rounded-lg flex items-center justify-center shrink-0 ${c.color}`}>
              <c.icon className="w-5 h-5" />
            </div>
            <div className="min-w-0">
              <p className="text-[11px] text-muted-foreground truncate">{c.label}</p>
              <p className="font-extrabold text-sm truncate">{c.value}</p>
            </div>
          </div>
        ))}
      </div>

      <Tabs defaultValue="levels">
        <TabsList className="mb-4">
          <TabsTrigger value="levels">موجودی انبارها</TabsTrigger>
          <TabsTrigger value="movements">گردش کالا</TabsTrigger>
        </TabsList>

        <TabsContent value="levels">
          <div className="flex flex-col sm:flex-row gap-2 mb-4">
            <form
              className="flex-1"
              onSubmit={(e) => {
                e.preventDefault();
                setPage(1);
                setSearch(searchText);
              }}
            >
              <div className="relative max-w-md">
                <Search className="absolute start-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground" />
                <Input className="ps-9" placeholder="جستجوی نام یا کد کالا…" value={searchText} onChange={(e) => setSearchText(e.target.value)} />
              </div>
            </form>
            <div className="flex gap-2">
              <Select
                value={warehouseFilter}
                onValueChange={(v) => {
                  setWarehouseFilter(v);
                  setPage(1);
                }}
              >
                <SelectTrigger className="w-40">
                  <SelectValue placeholder="همه انبارها" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="ALL">همه انبارها</SelectItem>
                  {warehouses.map((w) => (
                    <SelectItem key={w.id} value={w.id}>
                      {w.name}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <Select
                value={availability}
                onValueChange={(v) => {
                  setAvailability(v);
                  setPage(1);
                }}
              >
                <SelectTrigger className="w-36">
                  <SelectValue placeholder="همه" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="ALL">همه</SelectItem>
                  <SelectItem value="IN_STOCK">در انبار</SelectItem>
                  <SelectItem value="OUT_OF_STOCK">ناموجود</SelectItem>
                </SelectContent>
              </Select>
            </div>
          </div>

          <DataTable columns={levelColumns} rows={rows} loading={loading} page={page} pageSize={20} total={total} onPageChange={setPage} emptyText="موجودی ثبت نشده است. از «ثبت گردش موجودی» شروع کنید." />
        </TabsContent>

        <TabsContent value="movements">
          <div className="flex flex-col sm:flex-row gap-2 mb-4">
            <form
              className="flex-1"
              onSubmit={(e) => {
                e.preventDefault();
                setMPage(1);
                setMSearch(mSearchText);
              }}
            >
              <div className="relative max-w-md">
                <Search className="absolute start-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground" />
                <Input className="ps-9" placeholder="جستجوی کالا…" value={mSearchText} onChange={(e) => setMSearchText(e.target.value)} />
              </div>
            </form>
            <div className="flex gap-2">
              <Select
                value={mType}
                onValueChange={(v) => {
                  setMType(v);
                  setMPage(1);
                }}
              >
                <SelectTrigger className="w-40">
                  <SelectValue placeholder="همه انواع" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="ALL">همه انواع</SelectItem>
                  {MOVEMENT_TYPES.map((t) => (
                    <SelectItem key={t} value={t}>
                      {MOVEMENT_TYPE_LABELS[t]}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <Select
                value={mWarehouse}
                onValueChange={(v) => {
                  setMWarehouse(v);
                  setMPage(1);
                }}
              >
                <SelectTrigger className="w-40">
                  <SelectValue placeholder="همه انبارها" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="ALL">همه انبارها</SelectItem>
                  {warehouses.map((w) => (
                    <SelectItem key={w.id} value={w.id}>
                      {w.name}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
          </div>

          <DataTable columns={movementColumns} rows={mList.rows} loading={mList.loading} page={mPage} pageSize={20} total={mList.total} onPageChange={setMPage} emptyText="گردشی ثبت نشده است." />
        </TabsContent>
      </Tabs>

      {/* ── Movement dialog ── */}
      <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
        <DialogContent className="max-w-lg">
          <DialogHeader>
            <DialogTitle>ثبت گردش موجودی</DialogTitle>
          </DialogHeader>
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <div className="space-y-1.5">
              <Label>نوع گردش *</Label>
              <Select
                value={form.type}
                onValueChange={(v) => {
                  setForm({ ...form, type: v, fromWarehouseId: "", toWarehouseId: "" });
                  setCurrentQty(null);
                }}
              >
                <SelectTrigger>
                  <SelectValue />
                </SelectTrigger>
                <SelectContent>
                  {MOVEMENT_TYPES.map((t) => (
                    <SelectItem key={t} value={t}>
                      {MOVEMENT_TYPE_LABELS[t]}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>

            <div className="space-y-1.5">
              <Label>کالا *</Label>
              <Select
                value={form.productId}
                onValueChange={(v) => {
                  setForm({ ...form, productId: v });
                  probeCurrentQty(v, form.toWarehouseId);
                }}
              >
                <SelectTrigger>
                  <SelectValue placeholder="انتخاب کالا" />
                </SelectTrigger>
                <SelectContent>
                  {products.map((p) => (
                    <SelectItem key={p.id} value={p.id}>
                      {p.name}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>

            {(form.type === "OUT" || form.type === "TRANSFER") && (
              <div className="space-y-1.5">
                <Label>از انبار *</Label>
                <Select
                  value={form.fromWarehouseId}
                  onValueChange={(v) => setForm({ ...form, fromWarehouseId: v })}
                >
                  <SelectTrigger>
                    <SelectValue placeholder="انبار مبدأ" />
                  </SelectTrigger>
                  <SelectContent>
                    {warehouses.map((w) => (
                      <SelectItem key={w.id} value={w.id}>
                        {w.name}
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
              </div>
            )}

            {(form.type === "IN" || form.type === "TRANSFER" || form.type === "ADJUST") && (
              <div className="space-y-1.5">
                <Label>{form.type === "ADJUST" ? "انبار *" : "به انبار *"}</Label>
                <Select
                  value={form.toWarehouseId}
                  onValueChange={(v) => {
                    setForm({ ...form, toWarehouseId: v });
                    if (form.type === "ADJUST") probeCurrentQty(form.productId, v);
                  }}
                >
                  <SelectTrigger>
                    <SelectValue placeholder={form.type === "ADJUST" ? "انبار" : "انبار مقصد"} />
                  </SelectTrigger>
                  <SelectContent>
                    {warehouses.map((w) => (
                      <SelectItem key={w.id} value={w.id}>
                        {w.name}
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
              </div>
            )}

            {form.type === "ADJUST" && currentQty !== null && (
              <div className="sm:col-span-2 text-xs text-muted-foreground bg-muted/50 rounded-lg px-3 py-2">
                موجودی فعلی این کالا در انبار انتخابی: <b>{toPersianDigits(currentQty)}</b> — مقدار مثبت موجودی را افزایش و مقدار منفی کاهش می‌دهد.
              </div>
            )}

            <div className="space-y-1.5">
              <Label>{form.type === "ADJUST" ? "مقدار اصلاح (±)" : "تعداد *"}</Label>
              <Input
                dir="ltr"
                type="number"
                value={form.quantity}
                onChange={(e) => setForm({ ...form, quantity: e.target.value })}
                placeholder={form.type === "ADJUST" ? "مثلاً -۲ یا ۳" : "۱"}
              />
            </div>

            {form.type === "IN" && (
              <div className="space-y-1.5">
                <Label>بهای خرید هر واحد (ریال)</Label>
                <Input
                  dir="ltr"
                  type="number"
                  value={form.unitCost}
                  onChange={(e) => setForm({ ...form, unitCost: e.target.value })}
                />
              </div>
            )}

            <div className="space-y-1.5 sm:col-span-2">
              <Label>شرح</Label>
              <Textarea rows={2} value={form.note} onChange={(e) => setForm({ ...form, note: e.target.value })} placeholder="اختیاری" />
            </div>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setDialogOpen(false)}>انصراف</Button>
            <Button onClick={save} disabled={saving}>{saving ? "در حال ثبت…" : "ثبت گردش"}</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>

      {/* ── Stock card dialog ── */}
      <Dialog open={!!cardProduct} onOpenChange={(o) => !o && setCardProduct(null)}>
        <DialogContent className="max-w-2xl">
          <DialogHeader>
            <DialogTitle className="flex items-center gap-2">
              <TrendingDown className="w-4 h-4 rotate-180 text-emerald-600" />
              کارت کالا: {cardProduct?.name}
            </DialogTitle>
          </DialogHeader>
          {cardLoading ? (
            <div className="h-40 rounded-lg bg-muted animate-pulse" />
          ) : cardRows.length === 0 ? (
            <p className="text-sm text-muted-foreground py-8 text-center">گردشی برای این کالا ثبت نشده است.</p>
          ) : (
            <div className="rounded-xl border overflow-hidden max-h-[60vh] overflow-y-auto">
              <table className="w-full text-sm">
                <thead className="bg-muted/60 sticky top-0">
                  <tr>
                    <th className="text-start font-bold text-xs p-2.5">تاریخ</th>
                    <th className="text-start font-bold text-xs p-2.5">نوع</th>
                    <th className="text-start font-bold text-xs p-2.5">مسیر</th>
                    <th className="text-start font-bold text-xs p-2.5">تعداد</th>
                    <th className="text-start font-bold text-xs p-2.5">مرجع</th>
                  </tr>
                </thead>
                <tbody>
                  {cardRows.map((m) => (
                    <tr key={m.id} className="border-t">
                      <td className="p-2.5 text-xs text-muted-foreground">{formatJalaliDateTime(m.movedAt)}</td>
                      <td className="p-2.5">
                        <StatusBadge value={m.type} label={MOVEMENT_TYPE_LABELS[m.type] ?? m.type} />
                      </td>
                      <td className="p-2.5 text-xs text-muted-foreground">
                        {[m.fromWarehouse?.name, m.toWarehouse?.name].filter(Boolean).join(" ← ")}
                      </td>
                      <td className={`p-2.5 font-bold ${m.type === "OUT" || (m.type === "ADJUST" && m.quantity < 0) ? "text-rose-600" : "text-emerald-700"}`}>
                        {m.type === "OUT" || (m.type === "ADJUST" && m.quantity < 0) ? "−" : "+"}
                        {toPersianDigits(Math.abs(m.quantity))}
                      </td>
                      <td className="p-2.5 text-xs text-muted-foreground">
                        {m.refType ? MOVEMENT_REF_LABELS[m.refType] ?? m.refType : "—"}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          )}
        </DialogContent>
      </Dialog>
    </div>
  );
}
