namespace sacral20230904
{
    public class DocumentVerificationModel
    {
        public int Id { get; set; }
        
        public string WelcomingMessage { get; set; }
        
        public string Identity { get; set; }
        
        public string Address { get; set; }
        
        public bool IdentityVerified { get; set; }
        
        public bool AddressVerified { get; set; }
        
        public bool EligibleForBankingServices { get; set; }
        
        public decimal AnnualIncome { get; set; }
        
        public int CreditScore { get; set; }
        
        public string CreditCardEligibilityMessage { get; set; }
        
        public bool DisbursementApproved { get; set; }
        
        public decimal DisbursedAmount { get; set; }
        
        public decimal VehicleAssessmentValue { get; set; }
        
        public string VehicleAssessmentResultMessage { get; set; }
        
        public bool PaymentApprovalRequired { get; set; }
        
        public bool PaymentApproved { get; set; }
        
        public string VendorName { get; set; }
        
        public decimal PaymentAmount { get; set; }
        
        public string DisbursementProcessMessage { get; set; }
        
        public bool VendorInformationVerification { get; set; }
        
        public bool FundsAvailabilityConfirmed { get; set; }
        
        public bool PaymentApprovalGranted { get; set; }
        
        public string PaymentApprovalMessage { get; set; }
    }
}