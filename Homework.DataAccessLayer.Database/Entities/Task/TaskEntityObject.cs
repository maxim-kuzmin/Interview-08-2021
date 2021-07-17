namespace Homework.DataAccessLayer.Database.Entities.Task
{
    /// <summary>
    /// Объект сущности "Задача".
    /// </summary>
    public class TaskEntityObject
    {
        #region Properties

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        #endregion Properties
    }
}
