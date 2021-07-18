// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.ApplicationLayer.Task.Queries.Insert;
using Homework.ApplicationLayer.RabbitMQ.Producer;
using Homework.InfrastructureLayer.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace Homework.PresentationLayer.RabbitMQ.Producer.Controllers
{
    /// <summary>
    /// Контроллер задачи.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        #region Properties

        private IService Service { get; }

        private ILogger Logger { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="service">Сервис.</param>
        /// <param name="logger">Регистратор.</param>
        public TaskController(IService service, ILogger<TaskController> logger)
        {
            Service = service;

            Logger = logger;
        }

        #endregion Constructors

        #region Public methods

        [HttpPost]
        [ProducesResponseType(typeof(QueryResult), 200)]
        [SwaggerOperation("Добавить задачу")]
        public IActionResult Post([FromBody] TaskInsertQueryInput input)
        {
            QueryResult queryResult = new();

            try
            {
                Logger.LogInformation("Posted a task description: {0}", input.Description);

                Service.InsertTask(input);

                queryResult.IsOk = true;
            }
            catch (Exception ex)
            {
                queryResult.ErrorMessages.Add(ex.ToString());

                Logger.LogError(ex, null);
            }

            return Ok(queryResult);
        }

        #endregion Public methods
    }
}
