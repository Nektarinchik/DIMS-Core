using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Models;

namespace DIMS_Core.MappingProfiles;

public class TaskViewModelProfile : Profile
{
    public TaskViewModelProfile()
    {
        CreateMap<TaskModel, TaskViewModel>()
            .ReverseMap();
    }
}