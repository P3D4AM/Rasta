import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  output: "standalone",
  /* config options here */
  typescript: {
    ignoreBuildErrors: true,
  },
  reactStrictMode: false,
  // زیرساخت تست: سرور آزمایشی (vitest/playwright) با distDir جدا از سرور توسعه اجرا می‌شود
  // تا دو فرآیند next هم‌زمان روی یک .next ننویسند.
  ...(process.env.RASTA_TEST_DIST_DIR ? { distDir: process.env.RASTA_TEST_DIST_DIR } : {}),
};

export default nextConfig;
