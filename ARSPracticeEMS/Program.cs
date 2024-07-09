using ARSPracticeEMS.Repository;

namespace ARSPracticeEMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //repository middleware
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            //cors error
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });

            var app = builder.Build();

            app.UseCors("AllowAllOrigins");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
