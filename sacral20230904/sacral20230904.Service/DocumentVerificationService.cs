using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using sacral20230904.DataAccess;
using sacral20230904.DTO;

namespace sacral20230904.Service
{
    public class DocumentVerificationService : IDocumentVerificationService
    {
        private readonly IDbConnection connection;

        public DocumentVerificationService(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<DocumentVerificationModel> GetById(int id)
        {
            using (connection)
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM document_verification WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapToModel(reader);
                        }
                    }
                }
            }

            return null;
        }

        public async Task<List<DocumentVerificationModel>> GetAll()
        {
            var models = new List<DocumentVerificationModel>();

            using (connection)
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM document_verification";

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            models.Add(MapToModel(reader));
                        }
                    }
                }
            }

            return models;
        }

        public async Task<int> Create(DocumentVerificationModel model)
        {
            using (connection)
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO document_verification (welcoming_message, identity, address, identity_verified, address_verified, eligible_for_banking_services, annual_income, credit_score, credit_card_eligibility_message, disbursement_approved, disbursed_amount, vehicle_assessment_value, vehicle_assessment_result_message, payment_approval_required, payment_approved, vendor_name, payment_amount, disbursement_process_message, vendor_information_verification, funds_availability_confirmed, payment_approval_granted, payment_approval_message) VALUES (@welcomingMessage, @identity, @address, @identityVerified, @addressVerified, @eligibleForBankingServices, @annualIncome, @creditScore, @creditCardEligibilityMessage, @disbursementApproved, @disbursedAmount, @vehicleAssessmentValue, @vehicleAssessmentResultMessage, @paymentApprovalRequired, @paymentApproved, @vendorName, @paymentAmount, @disbursementProcessMessage, @vendorInformationVerification, @fundsAvailabilityConfirmed, @paymentApprovalGranted, @paymentApprovalMessage) RETURNING id";

                    command.Parameters.AddWithValue("@welcomingMessage", model.WelcomingMessage);
                    command.Parameters.AddWithValue("@identity", model.Identity);
                    command.Parameters.AddWithValue("@address", model.Address);
                    command.Parameters.AddWithValue("@identityVerified", model.IdentityVerified);
                    command.Parameters.AddWithValue("@addressVerified", model.AddressVerified);
                    command.Parameters.AddWithValue("@eligibleForBankingServices", model.EligibleForBankingServices);
                    command.Parameters.AddWithValue("@annualIncome", model.AnnualIncome);
                    command.Parameters.AddWithValue("@creditScore", model.CreditScore);
                    command.Parameters.AddWithValue("@creditCardEligibilityMessage", model.CreditCardEligibilityMessage);
                    command.Parameters.AddWithValue("@disbursementApproved", model.DisbursementApproved);
                    command.Parameters.AddWithValue("@disbursedAmount", model.DisbursedAmount);
                    command.Parameters.AddWithValue("@vehicleAssessmentValue", model.VehicleAssessmentValue);
                    command.Parameters.AddWithValue("@vehicleAssessmentResultMessage", model.VehicleAssessmentResultMessage);
                    command.Parameters.AddWithValue("@paymentApprovalRequired", model.PaymentApprovalRequired);
                    command.Parameters.AddWithValue("@paymentApproved", model.PaymentApproved);
                    command.Parameters.AddWithValue("@vendorName", model.VendorName);
                    command.Parameters.AddWithValue("@paymentAmount", model.PaymentAmount);
                    command.Parameters.AddWithValue("@disbursementProcessMessage", model.DisbursementProcessMessage);
                    command.Parameters.AddWithValue("@vendorInformationVerification", model.VendorInformationVerification);
                    command.Parameters.AddWithValue("@fundsAvailabilityConfirmed", model.FundsAvailabilityConfirmed);
                    command.Parameters.AddWithValue("@paymentApprovalGranted", model.PaymentApprovalGranted);
                    command.Parameters.AddWithValue("@paymentApprovalMessage", model.PaymentApprovalMessage);

                    return (int)await command.ExecuteScalarAsync();
                }
            }
        }

        public async Task<bool> Update(DocumentVerificationModel model)
        {
            using (connection)
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE document_verification SET welcoming_message = @welcomingMessage, identity = @identity, address = @address, identity_verified = @identityVerified, address_verified = @addressVerified, eligible_for_banking_services = @eligibleForBankingServices, annual_income = @annualIncome, credit_score = @creditScore, credit_card_eligibility_message = @creditCardEligibilityMessage, disbursement_approved = @disbursementApproved, disbursed_amount = @disbursedAmount, vehicle_assessment_value = @vehicleAssessmentValue, vehicle_assessment_result_message = @vehicleAssessmentResultMessage, payment_approval_required = @paymentApprovalRequired, payment_approved = @paymentApproved, vendor_name = @vendorName, payment_amount = @paymentAmount, disbursement_process_message = @disbursementProcessMessage, vendor_information_verification = @vendorInformationVerification, funds_availability_confirmed = @fundsAvailabilityConfirmed, payment_approval_granted = @paymentApprovalGranted, payment_approval_message = @paymentApprovalMessage WHERE id = @id";

                    command.Parameters.AddWithValue("@welcomingMessage", model.WelcomingMessage);
                    command.Parameters.AddWithValue("@identity", model.Identity);
                    command.Parameters.AddWithValue("@address", model.Address);
                    command.Parameters.AddWithValue("@identityVerified", model.IdentityVerified);
                    command.Parameters.AddWithValue("@addressVerified", model.AddressVerified);
                    command.Parameters.AddWithValue("@eligibleForBankingServices", model.EligibleForBankingServices);
                    command.Parameters.AddWithValue("@annualIncome", model.AnnualIncome);
                    command.Parameters.AddWithValue("@creditScore", model.CreditScore);
                    command.Parameters.AddWithValue("@creditCardEligibilityMessage", model.CreditCardEligibilityMessage);
                    command.Parameters.AddWithValue("@disbursementApproved", model.DisbursementApproved);
                    command.Parameters.AddWithValue("@disbursedAmount", model.DisbursedAmount);
                    command.Parameters.AddWithValue("@vehicleAssessmentValue", model.VehicleAssessmentValue);
                    command.Parameters.AddWithValue("@vehicleAssessmentResultMessage", model.VehicleAssessmentResultMessage);
                    command.Parameters.AddWithValue("@paymentApprovalRequired", model.PaymentApprovalRequired);
                    command.Parameters.AddWithValue("@paymentApproved", model.PaymentApproved);
                    command.Parameters.AddWithValue("@vendorName", model.VendorName);
                    command.Parameters.AddWithValue("@paymentAmount", model.PaymentAmount);
                    command.Parameters.AddWithValue("@disbursementProcessMessage", model.DisbursementProcessMessage);
                    command.Parameters.AddWithValue("@vendorInformationVerification", model.VendorInformationVerification);
                    command.Parameters.AddWithValue("@fundsAvailabilityConfirmed", model.FundsAvailabilityConfirmed);
                    command.Parameters.AddWithValue("@paymentApprovalGranted", model.PaymentApprovalGranted);
                    command.Parameters.AddWithValue("@paymentApprovalMessage", model.PaymentApprovalMessage);
                    command.Parameters.AddWithValue("@id", model.Id);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (connection)
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM document_verification WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        private DocumentVerificationModel MapToModel(DbDataReader reader)
        {
            return new DocumentVerificationModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                WelcomingMessage = reader.GetString(reader.GetOrdinal("welcoming_message")),
                Identity = reader.GetString(reader.GetOrdinal("identity")),
                Address = reader.GetString(reader.GetOrdinal("address")),
                IdentityVerified = reader.GetBoolean(reader.GetOrdinal("identity_verified")),
                AddressVerified = reader.GetBoolean(reader.GetOrdinal("address_verified")),
                EligibleForBankingServices = reader.GetBoolean(reader.GetOrdinal("eligible_for_banking_services")),
                AnnualIncome = reader.GetDecimal(reader.GetOrdinal("annual_income")),
                CreditScore = reader.GetInt32(reader.GetOrdinal("credit_score")),
                CreditCardEligibilityMessage = reader.GetString(reader.GetOrdinal("credit_card_eligibility_message")),
                DisbursementApproved = reader.GetBoolean(reader.GetOrdinal("disbursement_approved")),
                DisbursedAmount = reader.GetDecimal(reader.GetOrdinal("disbursed_amount")),
                VehicleAssessmentValue = reader.GetDecimal(reader.GetOrdinal("vehicle_assessment_value")),
                VehicleAssessmentResultMessage = reader.GetString(reader.GetOrdinal("vehicle_assessment_result_message")),
                PaymentApprovalRequired = reader.GetBoolean(reader.GetOrdinal("payment_approval_required")),
                PaymentApproved = reader.GetBoolean(reader.GetOrdinal("payment_approved")),
                VendorName = reader.GetString(reader.GetOrdinal("vendor_name")),
                PaymentAmount = reader.GetDecimal(reader.GetOrdinal("payment_amount")),
                DisbursementProcessMessage = reader.GetString(reader.GetOrdinal("disbursement_process_message")),
                VendorInformationVerification = reader.GetBoolean(reader.GetOrdinal("vendor_information_verification")),
                FundsAvailabilityConfirmed = reader.GetBoolean(reader.GetOrdinal("funds_availability_confirmed")),
                PaymentApprovalGranted = reader.GetBoolean(reader.GetOrdinal("payment_approval_granted")),
                PaymentApprovalMessage = reader.GetString(reader.GetOrdinal("payment_approval_message"))
            };
        }
    }
}
