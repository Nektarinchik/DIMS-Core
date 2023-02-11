using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Services;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DIMS_Core.Controllers;

public class TaskController : Controller
{
    private readonly ILogger<TaskController> _logger;
    private readonly TaskService _taskService;
    private readonly VTaskService _vTaskService;
    private readonly IMapper _mapper;

    public TaskController(ILogger<TaskController> logger, VTaskService vTaskService,
                          TaskService taskService,
                          IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _vTaskService = vTaskService;
        _taskService = taskService;
        _mapper = mapper;
    }
    // GET
    public async Task<ViewResult> Index()
    {
        var models = await _taskService.GetAll();
        var mappedModels = _mapper.Map<IEnumerable<TaskViewModel>>(models);
        return View(mappedModels);
    }
    public IActionResult Edit()
    {
        return View();
    }
    public IActionResult Delete()
    {
        return View();
    }
}