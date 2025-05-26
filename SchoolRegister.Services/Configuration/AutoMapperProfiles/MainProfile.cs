using AutoMapper;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;
using System.Linq;

namespace SchoolRegister.Services.Configuration.AutoMapperProfiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            // Subject → SubjectVm
            CreateMap<Subject, SubjectVm>()
                .ForMember(dest => dest.TeacherName,
                    opt => opt.MapFrom(src => src.Teacher == null
                        ? null
                        : $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
                .ForMember(dest => dest.Groups,
                    opt => opt.MapFrom(src => src.SubjectGroups.Select(sg => sg.Group)))
                .ReverseMap();

            // AddOrUpdateSubjectVm → Subject
            CreateMap<AddOrUpdateSubjectVm, Subject>();

            // SubjectVm → AddOrUpdateSubjectVm
            CreateMap<SubjectVm, AddOrUpdateSubjectVm>();

            // Group → GroupVm
            CreateMap<Group, GroupVm>()
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.Subjects,
                    opt => opt.MapFrom(src => src.SubjectGroups.Select(sg => sg.Subject)));

            // Student → StudentVm
            CreateMap<Student, StudentVm>()
                .ForMember(dest => dest.GroupName,
                    opt => opt.MapFrom(src => src.Group != null ? src.Group.Name : null))
                .ForMember(dest => dest.ParentName,
                    opt => opt.MapFrom(src => src.Parent != null
                        ? $"{src.Parent.FirstName} {src.Parent.LastName}"
                        : null));

            // Grade → GradeVm
            CreateMap<Grade, GradeVm>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.StudentName,
                    opt => opt.MapFrom(src => $"{src.Student.FirstName} {src.Student.LastName}"));

            // Teacher → TeacherVm
            CreateMap<Teacher, TeacherVm>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            // Parent → ParentVm
            CreateMap<Parent, ParentVm>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

        }
    }
}
