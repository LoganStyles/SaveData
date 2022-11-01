#!/bin/sh
sqlite3 output/School.db <<EOF
BEGIN TRANSACTION;

CREATE TABLE "Departments" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Departments" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NULL,
    "HOD" TEXT NULL
);

CREATE TABLE "Students" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Students" PRIMARY KEY AUTOINCREMENT,
    "FirstName" TEXT NULL,
    "LastName" TEXT NULL,
    "DepartmentCode" INTEGER NOT NULL
);

CREATE TABLE "Instructors" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Instructors" PRIMARY KEY AUTOINCREMENT,
    "FirstName" TEXT NULL,
    "LastName" TEXT NULL,
    "DepartmentCode" INTEGER NOT NULL,
    CONSTRAINT "FK_Instructors_Departments_DepartmentCode" FOREIGN KEY ("DepartmentCode") REFERENCES "Departments" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Instructors_DepartmentCode" ON "Instructors" ("DepartmentCode");

COMMIT;
EOF