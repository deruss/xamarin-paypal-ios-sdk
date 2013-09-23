using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using PayPalMobileForXamarin;
using System.Diagnostics;

namespace PayPalMobileSample2
{
    public class SamplePayPalPaymentDelegate : PayPalPaymentDelegate
    {
        PayPalMobileSample2ViewController HostViewController;

        public SamplePayPalPaymentDelegate (PayPalMobileSample2ViewController hostViewController)
        {
            HostViewController = hostViewController;
        }

        public override void PayPalPaymentDidComplete (PayPalPayment completedPayment)
        {
            HostViewController.PayPalPaymentDidComplete (completedPayment);
        }

        public override void PayPalPaymentDidCancel ()
        {
            HostViewController.PayPalPaymentDidCancel ();
        }
    }

    public partial class PayPalMobileSample2ViewController : UIViewController
    {

        const string kPayPalClientId = @"YOUR CLIENT ID HERE";
        const string kPayPalReceiverEmail = @"YOUR_PAYPAL_EMAIL@yourdomain.com";

        public string Environment { get; set; }

        public bool AcceptCreditCards { get; set; }

        public PayPalPayment CompletedPayment { get; set; }

        UIPopoverController FlipsidePopoverController;

        static bool UserInterfaceIdiomIsPhone {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public PayPalMobileSample2ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void DidReceiveMemoryWarning ()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning ();
            
            // Release any cached data, images, etc that aren't in use.
        }
        #region View lifecycle
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            
            this.Title = "PayPal iOS Library Demo";
            this.AcceptCreditCards = true;
            this.Environment = PayPalPaymentDelegate.PayPalEnvironmentNoNetwork;

            this.successView.Hidden = true;

            Debug.WriteLine ("PayPal iOS SDK version:" + PayPalPaymentViewController.LibraryVersion);
        }

        public override void ViewWillAppear (bool animated)
        {
            base.ViewWillAppear (animated);

            UIEdgeInsets insets = new UIEdgeInsets (0, 15f, 0, 14f);
            UIImage payBackgroundImage = UIImage.FromBundle ("button_secondary.png").CreateResizableImage (insets);
            UIImage payBackgroundImageHighlighted = UIImage.FromBundle ("button_secondary_selected.png").CreateResizableImage (insets);
            this.payButton.SetBackgroundImage (payBackgroundImage, UIControlState.Normal);
            this.payButton.SetBackgroundImage (payBackgroundImageHighlighted, UIControlState.Highlighted);
            this.payButton.SetTitleColor (UIColor.DarkGray, UIControlState.Normal);
            this.payButton.SetTitleColor (UIColor.DarkGray, UIControlState.Highlighted);

            // Optimization: Prepare for display of the payment UI by getting network work done early
            PayPalPaymentViewController.Environment = this.Environment;
            PayPalPaymentViewController.PrepareForPaymentUsingClientId (kPayPalClientId);
        }

        public override void ViewDidAppear (bool animated)
        {
            base.ViewDidAppear (animated);
        }

        public override void ViewWillDisappear (bool animated)
        {
            base.ViewWillDisappear (animated);
        }

        public override void ViewDidDisappear (bool animated)
        {
            base.ViewDidDisappear (animated);
        }
        #endregion
        PayPalPaymentViewController paymentViewController;
        SamplePayPalPaymentDelegate samplePayPalPaymentDelegate;

        partial void actPay (NSObject sender)
        {
            // Remove our last completed payment, just for demo purposes.
            this.CompletedPayment = null;

            var payment = new PayPalPayment () {
                Amount = new NSDecimalNumber("9.95"),
                CurrencyCode = "USD",
                ShortDescription = "Hipster t-shirt"
            };

            if (!payment.Processable) {
                // This particular payment will always be processable. If, for
                // example, the amount was negative or the shortDescription was
                // empty, this payment wouldn't be processable, and you'd want
                // to handle that here.
            }

            // Any customer identifier that you have will work here. Do NOT use a device- or
            // hardware-based identifier.
            string customerId = "user-11723";

            // Set the environment:
            // - For live charges, use PayPalEnvironmentProduction (default).
            // - To use the PayPal sandbox, use PayPalEnvironmentSandbox.
            // - For testing, use PayPalEnvironmentNoNetwork.
            PayPalPaymentViewController.Environment = this.Environment;
            samplePayPalPaymentDelegate = new SamplePayPalPaymentDelegate (this);

            paymentViewController = new PayPalPaymentViewController (kPayPalClientId,
                                                                    kPayPalReceiverEmail,
                                                                    customerId,
                                                                    payment,
                                                                    samplePayPalPaymentDelegate);

            if (paymentViewController.Handle == IntPtr.Zero) {
                Debug.WriteLine ("Failed to create PayPalPaymentViewController.");
                return;
            }

            paymentViewController.HideCreditCardButton = !this.AcceptCreditCards;

            // Setting the languageOrLocale property is optional.
            //
            // If you do not set languageOrLocale, then the PayPalPaymentViewController will present
            // its user interface according to the device's current language setting.
            //
            // Setting languageOrLocale to a particular language (e.g., @"es" for Spanish) or
            // locale (e.g., @"es_MX" for Mexican Spanish) forces the PayPalPaymentViewController
            // to use that language/locale.
            //
            // For full details, including a list of available languages and locales, see PayPalPaymentViewController.h.
            paymentViewController.LanguageOrLocale = "en";

            this.PresentViewController (paymentViewController, true, null);
        }

        void SendCompletedPaymentToServer (PayPalPayment completedPayment)
        {
            // TODO: Send completedPayment.confirmation to server
            Debug.WriteLine ("Here is your proof of payment:\n\n{0}\n\nSend this to your server for confirmation and fulfillment.", completedPayment.Confirmation);
        }
        // TODO: Expose this as a WeakDelegate through PayPalPaymentDelegate
        public void PayPalPaymentDidComplete (PayPalPayment completedPayment)
        {
            Debug.WriteLine ("PayPal Payment Success!");
            this.CompletedPayment = completedPayment;
            this.successView.Hidden = false;

            // Payment was processed successfully; send to server for verification and fulfillment
            this.SendCompletedPaymentToServer (completedPayment);
            this.DismissViewController (false, null);
        }
        // TODO: Expose this as a WeakDelegate through PayPalPaymentDelegate
        public void PayPalPaymentDidCancel ()
        {
            Debug.WriteLine ("PayPal Payment Canceled");
            this.CompletedPayment = null;
            this.successView.Hidden = true;
            this.DismissViewController (true, null);
        }
        // Flipside View Controller
        public void FlipsideViewControllerDidFinish (FlipsideViewController flipsideViewController)
        {
            if (UserInterfaceIdiomIsPhone) {
                this.DismissViewController (true, null);
            } else {
                this.FlipsidePopoverController.Dismiss (true);
                this.FlipsidePopoverController = null;
            }
        }
        //TODO
        //        - (void)popoverControllerDidDismissPopover:(UIPopoverController *)popoverController {
        //            self.flipsidePopoverController = nil;
        //        }
        //
        //
        [Export("popoverControllerDidDismissPopover:")]
        public void PopoverControllerDidDismiss (UIPopoverController popoverController)
        {
            this.FlipsidePopoverController = null;
        }

        public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue (segue, sender);

            if (segue.Identifier == "showAlternate") {
                ((FlipsideViewController)segue.DestinationViewController).Parent = this; 

                if (!UserInterfaceIdiomIsPhone) {
                    var popoverController = ((UIStoryboardPopoverSegue)segue).PopoverController;
                    this.FlipsidePopoverController = popoverController;
                    popoverController.WeakDelegate = this;
                }
            }
        }

        partial void actTogglePopover (NSObject sender)
        {
            if (this.FlipsidePopoverController != null) {
                this.FlipsidePopoverController.Dismiss (true);
                this.FlipsidePopoverController = null;
            } else {
                this.PerformSegue ("showAlternate", sender);
            }
        }


        //
        public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
        {
            // Return true for supported orientations
            if (UserInterfaceIdiomIsPhone) {
                return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
            } else {
                return true;
            }
        }
    }
}

