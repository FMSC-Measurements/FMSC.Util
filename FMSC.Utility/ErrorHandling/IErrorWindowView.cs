
namespace FMSC.Utility.ErrorHandling
{
    public interface IErrorWindowView
    {
        
        //bool IsScreenShotOptionEnabled { get; set; }
        //bool IsScreenShotOptionSelected { get; set; }
        //bool IsSendReportOptionSelected { get; set; }
        ErrorWindowLogic Presenter { get; set; }
        //string RecipiantEmail { get; set; }

        void Close();
      
    }
}
