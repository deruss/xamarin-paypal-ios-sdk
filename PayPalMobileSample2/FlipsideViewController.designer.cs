// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace PayPalMobileSample2
{
	[Register ("FlipsideViewController")]
	partial class FlipsideViewController
	{
		[Outlet]
		MonoTouch.UIKit.UISwitch acceptCreditCards { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl environmentSegmentedControl { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel proofOfPaymentLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView proofOfPaymentTextView { get; set; }

		[Action ("actDone:")]
		partial void actDone (MonoTouch.Foundation.NSObject sender);

		[Action ("environmentControlDidUpdate:")]
		partial void environmentControlDidUpdate (MonoTouch.Foundation.NSObject sender);

		[Action ("processCreditCardsChanged:")]
		partial void processCreditCardsChanged (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (environmentSegmentedControl != null) {
				environmentSegmentedControl.Dispose ();
				environmentSegmentedControl = null;
			}

			if (acceptCreditCards != null) {
				acceptCreditCards.Dispose ();
				acceptCreditCards = null;
			}

			if (proofOfPaymentTextView != null) {
				proofOfPaymentTextView.Dispose ();
				proofOfPaymentTextView = null;
			}

			if (proofOfPaymentLabel != null) {
				proofOfPaymentLabel.Dispose ();
				proofOfPaymentLabel = null;
			}
		}
	}
}
