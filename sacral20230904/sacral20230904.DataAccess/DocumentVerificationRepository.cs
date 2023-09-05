using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Npgsql;

namespace sacral20230904
{
    public class DocumentVerificationRepository : IDocumentVerificationService
    {
        private readonly string connectionString;

        public DocumentVerificationRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> AddAsync(DocumentVerificationModel documentVerification)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("INSERT INTO DocumentVerification (UserStory, AcceptanceCriteria, WelcomingMessage, IdentityVerificationMessage, AddressVerificationMessage, SuccessMessage, IncompleteVerificationMessage, AnnualIncome, CreditScore, CreditCardEligibilityMessage, DocumentVerificationCloseMessage, DisbursedAmount, VehicleAssessmentValue, VehicleAssessmentPassedMessage, VehicleAssessmentFailedMessage, PaymentApprovalMessage, DisbursementSuccessMessage, VendorName, VendorInformationVerificationStatus, FundsAvailabilityConfirmationStatus, PaymentApprovalStatus, PaymentAmount, VendorInformationInvalidMessage, PaymentApprovalPromptMessage) " +
                                                "VALUES (@UserStory, @AcceptanceCriteria, @WelcomingMessage, @IdentityVerificationMessage, @AddressVerificationMessage, @SuccessMessage, @IncompleteVerificationMessage, @AnnualIncome, @CreditScore, @CreditCardEligibilityMessage, @DocumentVerificationCloseMessage, @DisbursedAmount, @VehicleAssessmentValue, @VehicleAssessmentPassedMessage, @VehicleAssessmentFailedMessage, @PaymentApprovalMessage, @DisbursementSuccessMessage, @VendorName, @VendorInformationVerificationStatus, @FundsAvailabilityConfirmationStatus, @PaymentApprovalStatus, @PaymentAmount, @VendorInformationInvalidMessage, @PaymentApprovalPromptMessage) " +
                                                "RETURNING Id", connection);

                AddParameters(command, documentVerification);

                return (int)await command.ExecuteScalarAsync();
            }
        }

        public async Task<DocumentVerificationModel> GetByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("SELECT * FROM DocumentVerification WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return MapToDocumentVerificationModel(reader);
                    }

                    return null;
                }
            }
        }

        public async Task<List<DocumentVerificationModel>> GetAllAsync()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("SELECT * FROM DocumentVerification", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    var documentVerifications = new List<DocumentVerificationModel>();

                    while (await reader.ReadAsync())
                    {
                        documentVerifications.Add(MapToDocumentVerificationModel(reader));
                    }

                    return documentVerifications;
                }
            }
        }

        public async Task UpdateAsync(DocumentVerificationModel documentVerification)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("UPDATE DocumentVerification SET UserStory = @UserStory, AcceptanceCriteria = @AcceptanceCriteria, WelcomingMessage = @WelcomingMessage, IdentityVerificationMessage = @IdentityVerificationMessage, AddressVerificationMessage = @AddressVerificationMessage, SuccessMessage = @SuccessMessage, IncompleteVerificationMessage = @IncompleteVerificationMessage, AnnualIncome = @AnnualIncome, CreditScore = @CreditScore, CreditCardEligibilityMessage = @CreditCardEligibilityMessage, DocumentVerificationCloseMessage = @DocumentVerificationCloseMessage, DisbursedAmount = @DisbursedAmount, VehicleAssessmentValue = @VehicleAssessmentValue, VehicleAssessmentPassedMessage = @VehicleAssessmentPassedMessage, VehicleAssessmentFailedMessage = @VehicleAssessmentFailedMessage, PaymentApprovalMessage = @PaymentApprovalMessage, DisbursementSuccessMessage = @DisbursementSuccessMessage, VendorName = @VendorName, VendorInformationVerificationStatus = @VendorInformationVerificationStatus, FundsAvailabilityConfirmationStatus = @FundsAvailabilityConfirmationStatus, PaymentApprovalStatus = @PaymentApprovalStatus, PaymentAmount = @PaymentAmount, VendorInformationInvalidMessage = @VendorInformationInvalidMessage, PaymentApprovalPromptMessage = @PaymentApprovalPromptMessage " +
                                                "WHERE Id = @Id", connection);

                AddParameters(command, documentVerification);
                command.Parameters.AddWithValue("Id", documentVerification.Id);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("DELETE FROM DocumentVerification WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("Id", id);

                await command.ExecuteNonQueryAsync();
            }
        }

        private void AddParameters(NpgsqlCommand command, DocumentVerificationModel documentVerification)
        {
            command.Parameters.AddWithValue("UserStory", documentVerification.UserStory);
            command.Parameters.AddWithValue("AcceptanceCriteria", documentVerification.AcceptanceCriteria);
            command.Parameters.AddWithValue("WelcomingMessage", documentVerification.WelcomingMessage);
            command.Parameters.AddWithValue("IdentityVerificationMessage", documentVerification.IdentityVerificationMessage);
            command.Parameters.AddWithValue("AddressVerificationMessage", documentVerification.AddressVerificationMessage);
            command.Parameters.AddWithValue("SuccessMessage", documentVerification.SuccessMessage);
            command.Parameters.AddWithValue("IncompleteVerificationMessage", documentVerification.IncompleteVerificationMessage);
            command.Parameters.AddWithValue("AnnualIncome", documentVerification.AnnualIncome);
            command.Parameters.AddWithValue("CreditScore", documentVerification.CreditScore);
            command.Parameters.AddWithValue("CreditCardEligibilityMessage", documentVerification.CreditCardEligibilityMessage);
            command.Parameters.AddWithValue("DocumentVerificationCloseMessage", documentVerification.DocumentVerificationCloseMessage);
            command.Parameters.AddWithValue("DisbursedAmount", documentVerification.DisbursedAmount);
            command.Parameters.AddWithValue("VehicleAssessmentValue", documentVerification.VehicleAssessmentValue);
            command.Parameters.AddWithValue("VehicleAssessmentPassedMessage", documentVerification.VehicleAssessmentPassedMessage);
            command.Parameters.AddWithValue("VehicleAssessmentFailedMessage", documentVerification.VehicleAssessmentFailedMessage);
            command.Parameters.AddWithValue("PaymentApprovalMessage", documentVerification.PaymentApprovalMessage);
            command.Parameters.AddWithValue("DisbursementSuccessMessage", documentVerification.DisbursementSuccessMessage);
            command.Parameters.AddWithValue("VendorName", documentVerification.VendorName);
            command.Parameters.AddWithValue("VendorInformationVerificationStatus", documentVerification.VendorInformationVerificationStatus);
            command.Parameters.AddWithValue("FundsAvailabilityConfirmationStatus", documentVerification.FundsAvailabilityConfirmationStatus);
            command.Parameters.AddWithValue("PaymentApprovalStatus", documentVerification.PaymentApprovalStatus);
            command.Parameters.AddWithValue("PaymentAmount", documentVerification.PaymentAmount);
            command.Parameters.AddWithValue("VendorInformationInvalidMessage", documentVerification.VendorInformationInvalidMessage);
            command.Parameters.AddWithValue("PaymentApprovalPromptMessage", documentVerification.PaymentApprovalPromptMessage);
        }

        private DocumentVerificationModel MapToDocumentVerificationModel(IDataRecord record)
        {
            return new DocumentVerificationModel
            {
                Id = (int)record["Id"],
                UserStory = (string)record["UserStory"],
                AcceptanceCriteria = (string)record["AcceptanceCriteria"],
                WelcomingMessage = (string)record["WelcomingMessage"],
                IdentityVerificationMessage = (string)record["IdentityVerificationMessage"],
                AddressVerificationMessage = (string)record["AddressVerificationMessage"],
                SuccessMessage = (string)record["SuccessMessage"],
                IncompleteVerificationMessage = (string)record["IncompleteVerificationMessage"],
                AnnualIncome = (decimal)record["AnnualIncome"],
                CreditScore = (int)record["CreditScore"],
                CreditCardEligibilityMessage = (string)record["CreditCardEligibilityMessage"],
                DocumentVerificationCloseMessage = (string)record["DocumentVerificationCloseMessage"],
                DisbursedAmount = (decimal)record["DisbursedAmount"],
                VehicleAssessmentValue = (decimal)record["VehicleAssessmentValue"],
                VehicleAssessmentPassedMessage = (string)record["VehicleAssessmentPassedMessage"],
                VehicleAssessmentFailedMessage = (string)record["VehicleAssessmentFailedMessage"],
                PaymentApprovalMessage = (string)record["PaymentApprovalMessage"],
                DisbursementSuccessMessage = (string)record["DisbursementSuccessMessage"],
                VendorName = (string)record["VendorName"],
                VendorInformationVerificationStatus = (bool)record["VendorInformationVerificationStatus"],
                FundsAvailabilityConfirmationStatus = (bool)record["FundsAvailabilityConfirmationStatus"],
                PaymentApprovalStatus = (bool)record["PaymentApprovalStatus"],
                PaymentAmount = (decimal)record["PaymentAmount"],
                VendorInformationInvalidMessage = (string)record["VendorInformationInvalidMessage"],
                PaymentApprovalPromptMessage = (string)record["PaymentApprovalPromptMessage"]
            };
        }
    }
}