using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RefactorResume.Data;
using RefactorResume.Repositories;
using RefactorResume.Models;


namespace RefactorResume
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddTransient<ICertificationRepository, CertificationRepository>();
            builder.Services.AddTransient<IEducationRepository, EducationRepository>();
            builder.Services.AddTransient<IObjectiveRepository, ObjectiveRepository>();
            builder.Services.AddTransient<IPersonalInformationRepository, PersonalInformationRepository>();
            builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
            builder.Services.AddTransient<IReferenceRepository, ReferenceRepository>();
            builder.Services.AddTransient<IResumeRepository, ResumeRepository>();
            builder.Services.AddTransient<IResumeSectionRepository, ResumeSectionRepository>();
            builder.Services.AddTransient<ISkillRepository, SkillRepository>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IWorkExperienceRepository, WorkExperienceRepository>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseCors(options =>
                {
                    options.AllowAnyOrigin();
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                });
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}