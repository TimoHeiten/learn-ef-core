dotnet ef dbcontext scaffold "DataSource=data/leandb.db;foreign keys=true;" \
Microsoft.EntityFrameworkCore.SQlite \
-c LeanTrainingDbContext \
--context-dir DataAccess \
-o Models
