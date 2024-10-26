using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeSheetCreator.Data;
using GradeSheetCreator.Interfaces;
using GradeSheetCreator.Model;

namespace GradeSheetCreator.Worker
{
    public class WebViewService(ILedgerReader ledgerReader, IHTMLCreator htmlCreator)
    {
        private readonly ILedgerReader _ledgerReader = ledgerReader;
        private readonly IHTMLCreator _htmlCreator = htmlCreator;

        public string GetGradesheets() {
            Console.WriteLine("Getting Ledger");
            List<Model_Gradesheet> model_Gradesheets = _ledgerReader.GetGradesheets();
            Console.WriteLine("Got Ledger");
            Console.WriteLine("Getting Html");
            string webView = _htmlCreator.GetWebView(model_Gradesheets);
            Console.WriteLine("Hot Html");
            return webView;
        }
    }
}