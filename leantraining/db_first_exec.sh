dotnet ef dbcontext scaffold "DataSource=data/leandb.db;foreign_keys=true;" \
Microsoft.EntityFrameworkCore.SQlite \
-c LeanTrainingDbContext \
--context-dir DataAccess \
-o Models
