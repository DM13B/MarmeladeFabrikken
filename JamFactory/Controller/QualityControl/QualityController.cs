using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.QualityControl;
using Common.Interfaces;
using Model.QualityControl;

namespace Controller.QualityControl
{
    public class QualityController
    {
        DataAccessBinary DT = new DataAccessBinary();
        public IProductionProduct product;
        List<IProductionProduct> ProductionList = new List<IProductionProduct>();

        internal IProductionQualityCheck QualityCheck;
        static List<IProductionQualityCheck> QualityCheckList = new List<IProductionQualityCheck>();
        
        /// <summary>
        /// Creates a new product line
        /// </summary>
        /// <param name="name">Product Name</param>
        public void saveNewProductProduction(string name)
        {
            product = new ProductionProduct(name);

            DT.AddNewProduct(product);
            //product.ProductName = name;
        }

        /// <summary>
        /// Adds a Boolean quality control to the list
        /// </summary>
        /// <param name="name">Name of control</param>
        /// <param name="description">Description of control</param>
        /// <param name="controlType">Type of success (int, 2 int or bool)</param>
        /// <param name="eResultBool">Expected Result</param>
        /// <returns>The list of Quality checks + the newly added item</returns>
        public List<IProductionQualityCheck> addQualityCheckBool
            (string name,string description,int controlType,bool eResultBool) 
        {
            QualityCheck = new ProductionQualityCheck();

            QualityCheck.ControlName = name;
            QualityCheck.ControlDescription = description;                        
            QualityCheck.ControlType = controlType;
            QualityCheck.ExpectedBoolResult = eResultBool;

            QualityCheckList.Add(QualityCheck);
            return QualityCheckList;
        }

        /// <summary>
        /// Adds a double result quality control to the list
        /// </summary>
        /// <param name="name">Name of the control</param>
        /// <param name="description">Description of the control</param>
        /// <param name="controlType">Type of result</param>
        /// <param name="eResult1">First Expected result</param>
        /// <param name="eResult2">Second expected result</param>
        /// <returns>The list of Quality checks + the newly added item</returns>
        public List<IProductionQualityCheck> addQualityCheckDoubleResult(string name, string description, int controlType, string eResult1, string eResult2) 
        {
            QualityCheck = new ProductionQualityCheck();

            QualityCheck.ControlName = name;
            QualityCheck.ControlDescription = description;
            QualityCheck.ControlType = controlType;
            QualityCheck.ExpectedResult1 = eResult1;
            QualityCheck.ExpectedResult2 = eResult2;

            QualityCheckList.Add(QualityCheck);
            return QualityCheckList;
        }

        public List<IProductionProduct> loadAllProductionItems()
        {
            return DT.LoadProducts();
        }
    }
}
