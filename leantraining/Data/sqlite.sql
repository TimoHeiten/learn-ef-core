PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "AssemblySteps" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AssemblySteps" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Cost" INTEGER NOT NULL
);
CREATE TABLE IF NOT EXISTS "PartDefinitions" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PartDefinitions" PRIMARY KEY AUTOINCREMENT,
    "Cost" INTEGER NOT NULL,
    "Name" TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "Rounds" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Rounds" PRIMARY KEY AUTOINCREMENT,
    "Start" TEXT NOT NULL DEFAULT (datetime('now')),
    "End" TEXT NULL
);
CREATE TABLE IF NOT EXISTS "Products" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Products" PRIMARY KEY AUTOINCREMENT,
    "Start" TEXT NOT NULL DEFAULT (datetime('now')),
    "End" TEXT NULL,
    "RoundId" INTEGER NULL,
    CONSTRAINT "FK_Products_Rounds_RoundId" FOREIGN KEY ("RoundId") REFERENCES "Rounds" ("Id") ON DELETE RESTRICT
);
CREATE TABLE IF NOT EXISTS "Stations" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Stations" PRIMARY KEY AUTOINCREMENT,
    "RoundId" INTEGER NULL,
    "Position" TEXT NOT NULL,
    CONSTRAINT "FK_Stations_Rounds_RoundId" FOREIGN KEY ("RoundId") REFERENCES "Rounds" ("Id") ON DELETE RESTRICT
);
CREATE TABLE IF NOT EXISTS "Parts" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Parts" PRIMARY KEY AUTOINCREMENT,
    "ProductId" INTEGER NULL,
    "PartDefinitionId" INTEGER NULL,
    CONSTRAINT "FK_Parts_PartDefinitions_PartDefinitionId" FOREIGN KEY ("PartDefinitionId") REFERENCES "PartDefinitions" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Parts_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Products" ("Id") ON DELETE RESTRICT
);
CREATE TABLE IF NOT EXISTS "StationsAssemblyStepss" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_StationsAssemblyStepss" PRIMARY KEY AUTOINCREMENT,
    "StationId" INTEGER NULL,
    "AssemblyStepId" INTEGER NULL,
    CONSTRAINT "FK_StationsAssemblyStepss_AssemblySteps_AssemblyStepId" FOREIGN KEY ("AssemblyStepId") REFERENCES "AssemblySteps" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_StationsAssemblyStepss_Stations_StationId" FOREIGN KEY ("StationId") REFERENCES "Stations" ("Id") ON DELETE RESTRICT
);
DELETE FROM sqlite_sequence;
CREATE INDEX "IX_Parts_PartDefinitionId" ON "Parts" ("PartDefinitionId");
CREATE INDEX "IX_Parts_ProductId" ON "Parts" ("ProductId");
CREATE INDEX "IX_Products_RoundId" ON "Products" ("RoundId");
CREATE INDEX "IX_Stations_RoundId" ON "Stations" ("RoundId");
CREATE INDEX "IX_StationsAssemblyStepss_AssemblyStepId" ON "StationsAssemblyStepss" ("AssemblyStepId");
CREATE INDEX "IX_StationsAssemblyStepss_StationId" ON "StationsAssemblyStepss" ("StationId");
COMMIT;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
COMMIT;
