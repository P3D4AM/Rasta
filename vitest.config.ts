// Vitest — پیکربندی تست واحد و یکپارچه‌سازی رستا
// دو پروژه:
//   unit        — منطق خالص (بدون سرور، بدون دیتابیس)
//   integration — API واقعی روی سرور Next با دیتابیس آزمایشی ایزوله (spawn در globalSetup)

import { defineConfig } from "vitest/config";
import path from "node:path";

const ROOT = __dirname;

export default defineConfig({
  resolve: {
    alias: {
      // Next.js این بستهٔ مجازی را خودش فراهم می‌کند؛ در محیط vitest به استاب خالی مپ می‌شود
      "server-only": path.join(ROOT, "tests/helpers/server-only-stub.js"),
      "@": path.join(ROOT, "src"),
    },
  },
  test: {
    projects: [
      {
        test: {
          name: "unit",
          include: ["tests/unit/**/*.test.ts"],
          environment: "node",
        },
      },
      {
        test: {
          name: "integration",
          include: ["tests/integration/**/*.test.ts"],
          environment: "node",
          // زمان‌بندی سخاوتمندانه: اولین کامپایل on-demand مسیرها در next dev کند است
          testTimeout: 30_000,
          hookTimeout: 120_000,
          globalSetup: [path.join(ROOT, "tests/helpers/global-setup.ts")],
          setupFiles: [path.join(ROOT, "tests/helpers/integration-env.ts")],
        },
      },
    ],
  },
});
