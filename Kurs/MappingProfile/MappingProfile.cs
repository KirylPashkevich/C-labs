using AutoMapper;
using System.Text.RegularExpressions;
using Kurs.DTO;
using Kurs.Models;
namespace Kurs.MappingProfile
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForCtorParam("Name",
                opt => opt.MapFrom(g => string.Join(' ', g.Title, g.Description, g.DurationHours)));
            //CreateMap<Course, CourseDto>()
            //    .ForMember(g => g.Name,
            //    opt => opt.MapFrom(g => string.Join(' ', g.Title, g.Description, g.DurationHours)));
            CreateMap<CourseForCreationDto, Course>();
            CreateMap<CourseForUpdateDto, Course>();


            CreateMap<Kurs.Models.Group, GroupDto>()
                .ForCtorParam("GroupId", opt => opt.MapFrom(src => src.GroupID))
                .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name))
                .ForCtorParam("MaxStudents", opt => opt.MapFrom(src => src.MaxStudents));
            CreateMap<GroupForCreationDto, Kurs.Models.Group>();
            CreateMap<GroupForUpdateDto, Kurs.Models.Group>();

            CreateMap<Instructor, InstructorDto>()
           .ForCtorParam("FullName", opt => opt.MapFrom(src => string.Join(' ', src.FirstName, src.MiddleName, src.LastName)))
           .ForCtorParam("id", opt => opt.MapFrom(src => src.InstructorID))
           .ForCtorParam("ExperienceYears", opt => opt.MapFrom(src => src.ExperienceYears))
           .ForCtorParam("Phone", opt => opt.MapFrom(src => src.Phone));
            CreateMap<InstructorForCreationDto, Instructor>();
            CreateMap<InstructorForUpdateDto, Instructor > ();

            CreateMap<Lesson, LessonDto>()
                .ForCtorParam("Id", opt => opt.MapFrom(src => src.LessonID))
                .ForCtorParam("Descripiton", opt => opt.MapFrom(src => src.Description))
                .ForCtorParam("LessonType", opt => opt.MapFrom(src => src.LessonType));
            CreateMap<LessonForCreationDto, Lesson>();
            CreateMap<LessonForUpdateDto, Lesson>();


            CreateMap<Student, StudentDto>()
                .ForCtorParam("FullName", opt => opt.MapFrom(src => string.Join(' ', src.FirstName, src.MiddleName, src.LastName)))
                .ForCtorParam("id", opt => opt.MapFrom(src => src.StudentID))
                .ForCtorParam("Phone", opt => opt.MapFrom(src => src.Phone));

            CreateMap<StudentForCreationDto, Student>();
            CreateMap<StudentForUpdateDto, Student>();

        }
    }
}
