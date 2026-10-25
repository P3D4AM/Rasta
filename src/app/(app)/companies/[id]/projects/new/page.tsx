"use client";

import { use } from "react";
import { ProjectForm } from "@/components/rasta/project-form";

/** درج پروژه — /Company/CompanyInfo/ProjectInsert خود محصول */
export default function NewProjectPage({ params }: { params: Promise<{ id: string }> }) {
  const { id } = use(params);
  return <ProjectForm mode="insert" companyId={id} />;
}
