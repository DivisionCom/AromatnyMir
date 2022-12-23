//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ароматный_мир.AppData
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Order = new HashSet<Order>();
        }
    
        public string ProductArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductCategory { get; set; }
        public string ProductPhoto { get; set; }
        public int ProductManufacturer { get; set; }
        public decimal ProductCost { get; set; }
        public Nullable<byte> ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string ProductStatus { get; set; }
        public int ProductProvider { get; set; }
        public string ProductUnit { get; set; }
        public int ProductDiscountMax { get; set; }

        public string ColorBrush
        {
            get
            {
                if (ProductDiscountAmount > 15)
                    return "#7fff00";
                else
                    return "";
            }
        }

        public string ImagePath
        {
            get
            {
                return "/Resources/" + ProductPhoto;
            }
        }

        public string ManufacturerPath
        {
            get
            {
                return "Производитель: " + Manufacturer.ManufacturerName;
            }
        }

        public string CostPath
        {
            get
            {
                return "Цена: " + ProductCost;
            }
        }

        public string DiscountPath
        {
            get
            {
                return "Скидка " + ProductDiscountAmount + "%";
            }
        }


        public virtual Category Category { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Provider Provider { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}