using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWithCQRSPattern.Features.Product_Features.Commands.Create
{
    public class CreateProductCommand : IRequest<int>
    {
        private string _name;
        private string _barcode;
        private string _description;
        private string _confidentialData;

        public string Name 
        { 
            get
            {
                return _name;
            }
            set
            {
                _name = !string.IsNullOrEmpty(value) ? value.Trim() : value;
            }
        }

        public string Barcode
        {
            get
            {
                return _barcode;
            }
            set
            {
                _barcode = !string.IsNullOrEmpty(value) ? value.Trim() : value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = !string.IsNullOrEmpty(value) ? value.Trim() : value;
            }
        }

        public string ConfidentialData
        {
            get
            {
                return _confidentialData;
            }
            set
            {
                _confidentialData = !string.IsNullOrEmpty(value) ? value.Trim() : value;
            }
        }

        public bool IsActive { get; set; } = true;
        public decimal Rate { get; set; }
        public decimal BuyingPrice { get; set; }
    }
}
