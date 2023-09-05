namespace sacral20230904
{
    public class DocumentVerificationModel
    {
        public int Id { get; set; }
        public string UserStory { get; set; }
        public string AcceptanceCriteria { get; set; }
        public string WelcomingMessage { get; set; }
        public string IdentityVerificationMessage { get; set; }
        public string AddressVerificationMessage { get; set; }
        public string SuccessMessage { get; set; }
        public string IncompleteVerificationMessage { get; set; }
        public decimal AnnualIncome { get; set; }
        public int CreditScore { get; set; }
        public string CreditCardEligibilityMessage { get; set; }
        public string DocumentVerificationCloseMessage { get; set; }
        public decimal DisbursedAmount { get; set; }
        public decimal VehicleAssessmentValue { get; set; }
        public string VehicleAssessmentPassedMessage { get; set; }
        public string VehicleAssessmentFailedMessage { get; set; }
        public string PaymentApprovalMessage { get; set; }
        public string DisbursementSuccessMessage { get; set; }
        public string VendorName { get; set; }
        public bool VendorInformationVerificationStatus { get; set; }
        public bool FundsAvailabilityConfirmationStatus { get; set; }
        public bool PaymentApprovalStatus { get; set; }
        public decimal PaymentAmount { get; set; }
        public string VendorInformationInvalidMessage { get; set; }
        public string PaymentApprovalPromptMessage { get; set; }
    }
}