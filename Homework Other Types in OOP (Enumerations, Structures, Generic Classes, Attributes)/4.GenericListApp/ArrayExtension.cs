using System;

namespace GenericListApp
{
    public static class ArrayExtension
    {
        public static dynamic Resize<T>(this T[] arr)
        {
            T[] newArr = new T[arr.Length * 2];

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            return newArr;
        }
    }
}