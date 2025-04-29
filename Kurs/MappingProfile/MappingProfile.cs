using AutoMapper;
using Kurs.DTO;
using Kurs.Models;

namespace Kurs.MappingProfile
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<Group, GroupDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<Instructor, InstructorDto>();
            CreateMap<Lesson, LessonDto>();
        }
    }
}
