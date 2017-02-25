using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FYP_MVC.Models;
using FYP_MVC.Core.ContextRecognizer;
using FYP_MVC.Core.ObjectConversion;
using FYP_MVC.Models.CoreObjects;

namespace FYP_MVC.Unit_Testing
{
    [TestClass]
    public class ContextExtractorTest
    {
        [TestMethod]
        public void test_DateTime()
        {
            CSVFile csv = new CSVFile();
            Column col = new Column();
            csv.Data = new Column[1];
            csv.Data[0] = col;
            col.Data = new List<string>();
            col.Data.Add("2015");
            col.Data.Add("2014");
            col.Data.Add("April");
            col.Data.Add("2011");
            col.Data.Add("March");
            ContextExtractor con = new ContextExtractor(csv);
            Assert.AreEqual(3,3);

        }

        [TestMethod]
        public void test_ContextIdentificationNumeric()
        {
            ContextExtractor extractNumeric = new ContextExtractor();

            Column col = new Column();
            col.Data = new List<string>();
            col.Data.Add("0");
            col.Data.Add("2014");
            col.Data.Add("-13545.35");         
            col.Data.Add("3.52");
            col.Data.Add("422");

            col.Data.Add("-13545.35-435");
            col.Data.Add("March");

            extractNumeric.checkForNumeric(col);
            Assert.AreEqual(extractNumeric.getNumericCount(), 5);

        }

        [TestMethod]
        public void test_ContextIdentificationLocation()
        {
            ContextExtractor extractNumeric = new ContextExtractor();

            Column col = new Column();
            col.Data = new List<string>();
            col.Data.Add("Colombo");
            col.Data.Add("Galle");
            col.Data.Add("Sri Lanka");
            col.Data.Add("london");
            col.Data.Add("asia");

            col.Data.Add("llltt33");
            col.Data.Add("344");

            extractNumeric.checkForLocation(col);
            Assert.AreEqual(extractNumeric.getLocationCount(), 5);

        }

        [TestMethod]
        public void test_ContextIdentificationDate()
        {
            ContextExtractor extractNumeric = new ContextExtractor();

            Column col = new Column();
            col.Data = new List<string>();
            col.Data.Add("2007-04-15");
            col.Data.Add("Fri, 12 Dec 2014 10:55:50");
            col.Data.Add("1 hour ago");
            col.Data.Add("December 2015");
            col.Data.Add("tomorrow");

            col.Data.Add("asdlkfjlsadk");
            col.Data.Add("344.40y");
            col.Data.Add("433.333.3l");

            extractNumeric.checkForLocation(col);
            Assert.AreEqual(extractNumeric.getLocationCount(), 5);

        }

        [TestMethod]
        public void test_ContextIdentificationFloatingpoint()
        {
            ContextExtractor extractNumeric = new ContextExtractor();

            Column col = new Column();
            col.Data = new List<string>();
            col.Data.Add("1234");
            col.Data.Add("10000.0000001");
            col.Data.Add("1.392");
            col.Data.Add("-34.45");
            col.Data.Add("0.00");

            col.Data.Add("asdlkfjlsadk");
            col.Data.Add("344.40y");
            col.Data.Add("433.333.3l");
            col.Data.Add("343%4");


            extractNumeric.checkForLocation(col);
            Assert.AreEqual(extractNumeric.getLocationCount(), 5);

        }

        [TestMethod]
        public void test_ContextProcessNumericColumn()
        {
            Column col = new Column();
            col.Data = new List<string>();
            col.Data.Add("0");
            col.Data.Add("2014");
            col.Data.Add("-13545.35");
            col.Data.Add("3.52");
            col.Data.Add("422");

            col.Data.Add("-13545.35-435");
            col.Data.Add("March");

            ProcessConfirmedContext processConfirm = new ProcessConfirmedContext();
            processConfirm.processNumericColumn(col);
            Assert.AreEqual(processConfirm.errorRows.Count, 2);

        }

        [TestMethod]
        public void test_ContextProcessLocationColumn()
        {
            Column col = new Column();
            col.Data = new List<string>();
            col.Data.Add("Colombo");
            col.Data.Add("Galle");
            col.Data.Add("Sri Lanka");
            col.Data.Add("london");
            col.Data.Add("asia");

            col.Data.Add("llltt33");
            col.Data.Add("344");

            ProcessConfirmedContext processConfirm = new ProcessConfirmedContext();
            processConfirm.processLocationColumn(col);
            Assert.AreEqual(processConfirm.errorRows.Count, 2);

        }

        [TestMethod]
        public void test_ContextProcessDateColumn()
        {
            Column col = new Column();
            col.Data = new List<string>();
            col.Data.Add("2007-04-15");
            col.Data.Add("Fri, 12 Dec 2014 10:55:50");
            col.Data.Add("1 hour ago");
            col.Data.Add("December 2015");
            col.Data.Add("tomorrow");

            col.Data.Add("asdlkfjlsadk");
            col.Data.Add("344.40y");
            col.Data.Add("433.333.3l");

            ProcessConfirmedContext processConfirm = new ProcessConfirmedContext();
            processConfirm.processDateColumn(col);
            Assert.AreEqual(processConfirm.errorRows.Count, 3);

        }

        [TestMethod]
        public void test_ContextProcessNominalColumn()
        {
            Column col = new Column();
            col.Data = new List<string>();
            col.Data.Add("2007-04-15");
            col.Data.Add("Fri, 12 Dec 2014 10:55:50");
            col.Data.Add("1 hour ago");
            col.Data.Add("December 2015");
            col.Data.Add("tomorrow");

            col.Data.Add("");

            ProcessConfirmedContext processConfirm = new ProcessConfirmedContext();
            processConfirm.processNominalColumn(col);
            Assert.AreEqual(processConfirm.errorRows.Count, 1);

        }

        [TestMethod]
        public void test_ContextProcessRemoveError()
        {
            CSVFile file = new CSVFile();
            file.Data = new Column[10];


        }


        [TestMethod]
        public void test_Convert_CSV_to_Chart_Convert()
        {
            Column col = new Column();
            col.Data = new List<string>();
            col.Data.Add("0");
            col.Data.Add("2014");
            col.Data.Add("-13545.35");
            col.Data.Add("3.52");
            col.Data.Add("422");

            Column[] colAr = { col };

            Convert_CSV_to_Chart converter = new Convert_CSV_to_Chart();
            //Data<Double>[] result = converter.processNumericColumn(col);
            

            CSVFile csv = new CSVFile();
            csv.Data = colAr;
            ChartComponent chart=new ChartComponent();
            var res=converter.Convert(csv, chart);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void test_Convert_CSV_to_Chart_ProcessNumericColumn()
        {
            Column col = new Column();
            col.Data = new List<string>();
            col.Data.Add("0");
            col.Data.Add("2014");
            col.Data.Add("-13545.35");
            col.Data.Add("3.52");
            col.Data.Add("422");

            Column[] colAr = { col };

            Convert_CSV_to_Chart converter = new Convert_CSV_to_Chart();
            //


            CSVFile csv = new CSVFile();
            csv.Data = colAr;
            ChartComponent chart = new ChartComponent();
            var res = converter.Convert(csv, chart);
            Data<Double>[] result = converter.processNumericColumn(col);

            Assert.AreEqual(2014, result[1].value);
        }

        [TestMethod]
        public void test_Convert_CSV_to_Chart_processNominalColumn()
        {
            Column col = new Column();
            col.Data = new List<string>();
            col.Data.Add("kdkdk");
            col.Data.Add("awe");
            col.Data.Add("-1354aadsfew");
            col.Data.Add("qdfdsf");
            col.Data.Add("a4wfdsf");

            Column[] colAr = { col };

            Convert_CSV_to_Chart converter = new Convert_CSV_to_Chart();
            //


            CSVFile csv = new CSVFile();
            csv.Data = colAr;
            ChartComponent chart = new ChartComponent();
            var res = converter.Convert(csv, chart);
            Data<string>[] result = converter.processNominalColumn(col);

            Assert.AreEqual("awe", result[1].value);
        }
        [TestMethod]
        public void test_Convert_CSV_to_Chart_processLocationColumn()
        {
            Column col = new Column();
            col.Data = new List<string>();
            col.Data.Add("colombo");
            col.Data.Add("london");
            col.Data.Add("delli");
            col.Data.Add("asia");
            col.Data.Add("india");

            Column[] colAr = { col };

            Convert_CSV_to_Chart converter = new Convert_CSV_to_Chart();
            //


            CSVFile csv = new CSVFile();
            csv.Data = colAr;
            ChartComponent chart = new ChartComponent();
            var res = converter.Convert(csv, chart);
            Data<string>[] result = converter.processLocationColumn(col);

            Assert.AreEqual("london", result[1].value);
        }

        [TestMethod]
        public void test_Convert_CSV_to_Chart_processDateColumn()
        {
            Column col = new Column();
            col.Data = new List<string>();
            col.Data.Add("colombo");
            col.Data.Add("london");
            col.Data.Add("delli");
            col.Data.Add("asia");
            col.Data.Add("india");
            col.DateValues = new System.DateTime[]{
                new System.DateTime(2008, 5, 11, 8, 30, 51),
                new System.DateTime(2015, 6, 2, 9, 26, 52),
                new System.DateTime(2008, 10, 7, 12, 58, 42),
                new System.DateTime(2008, 7, 5, 12, 55, 23),
                new System.DateTime(2008, 1, 10, 2, 35, 44)
            };

            Column[] colAr = { col };

            Convert_CSV_to_Chart converter = new Convert_CSV_to_Chart();
            //


            CSVFile csv = new CSVFile();
            csv.Data = colAr;
            ChartComponent chart = new ChartComponent();
            var res = converter.Convert(csv, chart);
            Data<string>[] result = converter.processDateColumn(col);

            Assert.AreEqual("2015-06-02", result[1].value);
        }
    }
}