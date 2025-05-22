dotnet ef dbcontext scaffold "Server=localhost\MSSQLSERVER01;Database=Test;Trusted_Connection=True;Initial Catalog=Test" Microsoft.EntityFrameworkCore.SqlServer -o Entities/New -c “Test" -f -v -t users

dotnet ef dbcontext scaffold "Server=localhost\MSSQLSERVER01;Database=master;Trusted_Connection=True;;Initial Catalog=Test" Microsoft.EntityFrameworkCore.SqlServer -table Users