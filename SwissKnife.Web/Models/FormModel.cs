using SwissKnife.Mvc;

namespace SwissKnife.Web.Models
{
    public class FormModel
    {
        [Contains(typeof(Master), "PrefectureList", ErrorMessage = "正しい都道府県を選択してください。")]
        public int PrefectureId { get; set; }

        [Contains(typeof(Master), "ColorList", ErrorMessage = "正しい色を選択してください。")]
        public int[] ColorId { get; set; }

        [Contains(typeof(Master), "ToggleList")]
        public Toggle ToggleId { get; set; }
    }
}