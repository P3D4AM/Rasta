import { getCurrentUser } from "@/lib/auth";
import { handle, json } from "@/lib/http";

export async function GET() {
  return handle(async () => {
    const user = await getCurrentUser();
    if (!user) return json({ user: null }, 401);
    return json({ user });
  });
}
