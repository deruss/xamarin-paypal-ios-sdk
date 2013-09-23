//using System;
//
//namespace PayPalMobileForXamarin {
//
//	[BaseType (typeof (NSObject))]
//	public partial interface PayPalPayment {
//
//		[Static, Export ("PaymentWithAmount")]
//		PayPalPayment PaymentWithAmount (NSDecimalNumber amount, string currencyCode, string shortDescription);
//
//		[Export ("currencyCode", ArgumentSemantic.Copy)]
//		string CurrencyCode { get; set; }
//
//		[Export ("amount", ArgumentSemantic.Copy)]
//		NSDecimalNumber Amount { get; set; }
//
//		[Export ("shortDescription", ArgumentSemantic.Copy)]
//		string ShortDescription { get; set; }
//
//		[Export ("processable")]
//		bool Processable { get; }
//
//		[Export ("localizedAmountForDisplay", ArgumentSemantic.Copy)]
//		string LocalizedAmountForDisplay { get; }
//
//		[Export ("confirmation", ArgumentSemantic.Copy)]
//		NSDictionary Confirmation { get; }
//	}
//
//	[Model, BaseType (typeof (NSObject))]
//	public partial interface PayPalPaymentDelegate {
//
//		[Export ("PayPalPaymentDidCancel")]
//		void PayPalPaymentDidCancel ();
//
//		[Export ("PayPalPaymentDidComplete")]
//		void PayPalPaymentDidComplete (PayPalPayment completedPayment);
//
//		[Notification, Field ("PayPalTransactionDidSucceedNotification")]
//		NSString PayPalTransactionDidSucceedNotification { get; }
//
//		[Field ("PayPalEnvironmentProduction")]
//		NSString PayPalEnvironmentProduction { get; }
//
//		[Field ("PayPalEnvironmentSandbox")]
//		NSString PayPalEnvironmentSandbox { get; }
//
//		[Field ("PayPalEnvironmentNoNetwork")]
//		NSString PayPalEnvironmentNoNetwork { get; }
//	}
//
//	[BaseType (typeof (UINavigationController))]
//	public partial interface PayPalPaymentViewController {
//
//		[Export ("InitWithClientId")]
//		IntPtr Constructor (string clientId, string payPalAccountEmailAddress, string payerId, PayPalPayment payment, PayPalPaymentDelegate delegate);
//
//		[Export ("paymentDelegate", ArgumentSemantic.Assign)]
//		PayPalPaymentDelegate PaymentDelegate { get; set; }
//
//		[Export ("languageOrLocale", ArgumentSemantic.Copy)]
//		string LanguageOrLocale { get; set; }
//
//		[Static, Export ("Environment"), Verify ("ObjC method massaged into getter property", "/Users/davidrusell/PayPal-iOS-SDK/PayPalMobile/PayPalPaymentViewController.h", Line = 117), Verify ("Backing setter method to ObjC property removed: SetEnvironment", "/Users/davidrusell/PayPal-iOS-SDK/PayPalMobile/PayPalPaymentViewController.h", Line = 126)]
//		string Environment { get; set; }
//
//		[Static, Export ("PrepareForPaymentUsingClientId")]
//		void PrepareForPaymentUsingClientId (string clientId);
//
//		[Export ("defaultUserEmail", ArgumentSemantic.Copy)]
//		string DefaultUserEmail { get; set; }
//
//		[Export ("defaultUserPhoneCountryCode", ArgumentSemantic.Copy)]
//		string DefaultUserPhoneCountryCode { get; set; }
//
//		[Export ("defaultUserPhoneNumber", ArgumentSemantic.Copy)]
//		string DefaultUserPhoneNumber { get; set; }
//
//		[Export ("hideCreditCardButton")]
//		bool HideCreditCardButton { get; set; }
//
//		[Export ("disableBlurWhenBackgrounding")]
//		bool DisableBlurWhenBackgrounding { get; set; }
//
//		[Export ("state")]
//		PayPalPaymentViewControllerState State { get; }
//
//		[Static, Export ("LibraryVersion"), Verify ("ObjC method massaged into getter property", "/Users/davidrusell/PayPal-iOS-SDK/PayPalMobile/PayPalPaymentViewController.h", Line = 194)]
//		string LibraryVersion { get; }
//	}
//
//	public enum PayPalPaymentViewControllerState : [unmapped: unexposed: Elaborated] {
//		Unsent = 0,
//		InProgress = 1,
//		Successful = 2
//	}
//
//	public enum PayPalPaymentViewControllerState {
//		Unsent = 0,
//		InProgress = 1,
//		Successful = 2
//	}
//
//	[BaseType (typeof (NSObject))]
//	public partial interface PayPalPayment {
//
//		[Static, Export ("PaymentWithAmount")]
//		PayPalPayment PaymentWithAmount (NSDecimalNumber amount, string currencyCode, string shortDescription);
//
//		[Export ("currencyCode", ArgumentSemantic.Copy)]
//		string CurrencyCode { get; set; }
//
//		[Export ("amount", ArgumentSemantic.Copy)]
//		NSDecimalNumber Amount { get; set; }
//
//		[Export ("shortDescription", ArgumentSemantic.Copy)]
//		string ShortDescription { get; set; }
//
//		[Export ("processable")]
//		bool Processable { get; }
//
//		[Export ("localizedAmountForDisplay", ArgumentSemantic.Copy)]
//		string LocalizedAmountForDisplay { get; }
//
//		[Export ("confirmation", ArgumentSemantic.Copy)]
//		NSDictionary Confirmation { get; }
//	}
//
//	[BaseType (typeof (NSObject))]
//	public partial interface PayPalPayment {
//
//		[Static, Export ("PaymentWithAmount")]
//		PayPalPayment PaymentWithAmount (NSDecimalNumber amount, string currencyCode, string shortDescription);
//
//		[Export ("currencyCode", ArgumentSemantic.Copy)]
//		string CurrencyCode { get; set; }
//
//		[Export ("amount", ArgumentSemantic.Copy)]
//		NSDecimalNumber Amount { get; set; }
//
//		[Export ("shortDescription", ArgumentSemantic.Copy)]
//		string ShortDescription { get; set; }
//
//		[Export ("processable")]
//		bool Processable { get; }
//
//		[Export ("localizedAmountForDisplay", ArgumentSemantic.Copy)]
//		string LocalizedAmountForDisplay { get; }
//
//		[Export ("confirmation", ArgumentSemantic.Copy)]
//		NSDictionary Confirmation { get; }
//	}
//
//	[Model, BaseType (typeof (NSObject))]
//	public partial interface PayPalPaymentDelegate {
//
//		[Export ("PayPalPaymentDidCancel")]
//		void PayPalPaymentDidCancel ();
//
//		[Export ("PayPalPaymentDidComplete")]
//		void PayPalPaymentDidComplete (PayPalPayment completedPayment);
//
//		[Notification, Field ("PayPalTransactionDidSucceedNotification")]
//		NSString PayPalTransactionDidSucceedNotification { get; }
//
//		[Field ("PayPalEnvironmentProduction")]
//		NSString PayPalEnvironmentProduction { get; }
//
//		[Field ("PayPalEnvironmentSandbox")]
//		NSString PayPalEnvironmentSandbox { get; }
//
//		[Field ("PayPalEnvironmentNoNetwork")]
//		NSString PayPalEnvironmentNoNetwork { get; }
//	}
//
//	[BaseType (typeof (UINavigationController))]
//	public partial interface PayPalPaymentViewController {
//
//		[Export ("InitWithClientId")]
//		IntPtr Constructor (string clientId, string payPalAccountEmailAddress, string payerId, PayPalPayment payment, PayPalPaymentDelegate delegate);
//
//		[Export ("paymentDelegate", ArgumentSemantic.Assign)]
//		PayPalPaymentDelegate PaymentDelegate { get; set; }
//
//		[Export ("languageOrLocale", ArgumentSemantic.Copy)]
//		string LanguageOrLocale { get; set; }
//
//		[Static, Export ("Environment"), Verify ("ObjC method massaged into getter property", "/Users/davidrusell/PayPal-iOS-SDK/PayPalMobile/PayPalPaymentViewController.h", Line = 117), Verify ("Backing setter method to ObjC property removed: SetEnvironment", "/Users/davidrusell/PayPal-iOS-SDK/PayPalMobile/PayPalPaymentViewController.h", Line = 126)]
//		string Environment { get; set; }
//
//		[Static, Export ("PrepareForPaymentUsingClientId")]
//		void PrepareForPaymentUsingClientId (string clientId);
//
//		[Export ("defaultUserEmail", ArgumentSemantic.Copy)]
//		string DefaultUserEmail { get; set; }
//
//		[Export ("defaultUserPhoneCountryCode", ArgumentSemantic.Copy)]
//		string DefaultUserPhoneCountryCode { get; set; }
//
//		[Export ("defaultUserPhoneNumber", ArgumentSemantic.Copy)]
//		string DefaultUserPhoneNumber { get; set; }
//
//		[Export ("hideCreditCardButton")]
//		bool HideCreditCardButton { get; set; }
//
//		[Export ("disableBlurWhenBackgrounding")]
//		bool DisableBlurWhenBackgrounding { get; set; }
//
//		[Export ("state")]
//		PayPalPaymentViewControllerState State { get; }
//
//		[Static, Export ("LibraryVersion"), Verify ("ObjC method massaged into getter property", "/Users/davidrusell/PayPal-iOS-SDK/PayPalMobile/PayPalPaymentViewController.h", Line = 194)]
//		string LibraryVersion { get; }
//	}
//
//	public enum PayPalPaymentViewControllerState : [unmapped: unexposed: Elaborated] {
//		Unsent = 0,
//		InProgress = 1,
//		Successful = 2
//	}
//
//	public enum PayPalPaymentViewControllerState {
//		Unsent = 0,
//		InProgress = 1,
//		Successful = 2
//	}
//}
