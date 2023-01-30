using AutoMapper;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.MappingProfiles;

public class TaskTrackViewModel : Profile
{
    public TaskTrackViewModel()
    {
        CreateMap<TaskTrackViewModel, TaskTrackViewModel>()
            .ReverseMap();
    }
}