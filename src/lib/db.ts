import { PrismaClient } from '@prisma/client'

const globalForPrisma = globalThis as unknown as {
  prisma: PrismaClient | undefined
}

export const db =
  globalForPrisma.prisma ??
  new PrismaClient({
    // در حالت production لاگ کوئری‌ها خاموش است: متن SQL شامل داده‌های حساس
    // (هش رمز، توکن‌ها) می‌شود و حجم لاگ را بی‌دلیل بالا می‌برد.
    log: process.env.NODE_ENV === 'production' ? ['error', 'warn'] : ['query'],
  })

if (process.env.NODE_ENV !== 'production') globalForPrisma.prisma = db