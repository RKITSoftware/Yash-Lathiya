namespace _5_1_Uses_My_Base_Library
{
    class MySortedList<T> : List<T> 
    {
        // Override the Add method to customize behavior
        public new void Add(T item)
        {
            base.Add(item);
            base.Sort();
        }

        // Override the Remove method to customize behavior
        public new bool Remove(T item)
        {
            if(base.Remove(item))
            {
                base.Sort();
                return true;
            }

            return false;
        }

    }
}
