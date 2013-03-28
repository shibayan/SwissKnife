using SwissKnife.Mvc;

namespace SwissKnife.Web.Models
{
    public class FormModel
    {
        [Contains(typeof(Master), "PrefectureList")]
        public int PrefectureId { get; set; }

        [Contains(typeof(Master), "ColorList")]
        public int ColorId { get; set; }
    }
}