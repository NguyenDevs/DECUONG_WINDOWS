using System;
class Program{
    static void Main(){
        Console.WriteLine("Nhap vao chieu dai cua mang: ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0){
            Console.WriteLine("Vui nhap vao mot so nguyen duong: ");
        }
        int[] arr = new int[n];
        // Nhập mảng từ bàn phím
        for (int i = 0; i < n; i++){
            Console.Write($"Nhap phan tu thu {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out arr[i])){
                Console.WriteLine("Vui long nhap vao mot so nguyen");
            }
        }
        // Sắp xếp mảng
        Array.Sort(arr);
        // Hiển thị mảng đã sắp xếp
        Console.WriteLine("Mang da sap xep theo thu tu tang dan:");
        for (int i = 0; i < n; i++){
            Console.Write($"{arr[i]} ");
        }
        Console.WriteLine(); // Xuống dòng sau khi hiển thị mảng
    }
}
