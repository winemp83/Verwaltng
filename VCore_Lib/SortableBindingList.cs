using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace VCore_Lib
{
    [Serializable()]
    public class SortableBindingList<T> : BindingList<T>, ITypedList
    {
        [NonSerialized()]
        private readonly PropertyDescriptorCollection properties;

        public SortableBindingList()
            : base()
        {
            // Get the 'shape' of the list. 
            // Only get the public properties marked with Browsable = true.
            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(
                typeof(T),
                new Attribute[] { new BrowsableAttribute(true) });

            // Sort the properties.
            properties = pdc.Sort();
        }

        #region ITypedList Implementation

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            PropertyDescriptorCollection pdc;
            if (null == listAccessors)
            {
                // Return properties in sort order.
                pdc = properties;
            }
            else
            {
                // Return child list shape.
                pdc = ListBindingHelper.GetListItemProperties(listAccessors[0].PropertyType);
            }

            return pdc;
        }

        // This method is only used in the design-time framework 
        // and by the obsolete DataGrid control.
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return typeof(T).Name;
        }

        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }

        protected override bool IsSortedCore
        {
            get
            {
                return base.IsSortedCore;
            }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return base.SortPropertyCore;
            }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return base.SortDirectionCore;
            }
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            List<T> helper = (List<T>)this.Items;
            this.currentProperty = prop;
            this.currentDirection = direction;
            helper.Sort(Compare);

        }
        [NonSerialized]
        private PropertyDescriptor currentProperty;
        [NonSerialized]
        private ListSortDirection currentDirection;

        private int Compare(T a, T b)
        {
            object valA = currentProperty.GetValue(a);
            object valB = currentProperty.GetValue(b);

            IComparable icA = valA as IComparable;
            IComparable icB = valB as IComparable;

            if (icA == null && icB == null)
            {
                return 0;
            }

            if (icA == null && icB != null)
            {
                return currentDirection == ListSortDirection.Ascending ? -1 : 1;
            }

            if (icA != null && icB == null)
            {
                return currentDirection == ListSortDirection.Ascending ? 1 : -1;
            }


            if (currentDirection == ListSortDirection.Ascending)
            {
                return icA.CompareTo(icB);
            }
            else
            {
                return -icA.CompareTo(icB);
            }
        }

        protected override void RemoveSortCore()
        {

        }

        #endregion

        public void AddRange(IEnumerable<T> itemsToAdd)
        {
            foreach (T item in itemsToAdd)
            {
                this.Add(item);
            }
        }

    }
}
