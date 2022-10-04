using FraudProtection;

Console.WriteLine("Fraud Protection!");

var logic = new FraudProtectionLogic();
int[] arr = new int[] { 1, 9, 6, 7, 5, 9 };
var notificationCount = logic.GetNotificationCount();
Console.WriteLine($"Notification count: {notificationCount}");