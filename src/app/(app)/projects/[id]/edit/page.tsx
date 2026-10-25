"use client";

import { use } from "react";
import { ProjectForm } from "@/components/rasta/project-form";

/** ویرایش پروژه — /Company/CompanyInfo/ProjectEdit خود محصول (companyId فقط در درج مصرف می‌شود) */
export default function EditProjectPage({ params }: { params: Promise<{ id: string }> }) {
  const { id } = use(params);
  return <ProjectForm mode="edit" companyId="" projectId={id} />;
}
