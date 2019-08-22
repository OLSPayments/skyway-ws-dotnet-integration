# skyway-ws-dotnet-integration
.Net Example to interface with OLS.Payments Skyway Web Services sending a json payload:

Requires .NET Core - https://dotnet.microsoft.com/download

Remember to set proper URL, accessID, accessKey, merchant_number, store_number, and rsaKeyId values in appsettings.json. 
Also populate the publickey.pem file with your public key.

Run in VSCode or Terminal:

Example run and output

```
$ dotnet run
Hello Skyway!

Sending Request to: https://hostname.domain.com:<port>/fsd/J.01-A

Request
********************************************
X-InComm-DateTime: 2019-08-22T13:10:23.923Z
Content-Type: application/json
Accept: application/json; version=3
Accept-Language: en
Authorization: InComm ****************:****************************
{
  "application_type": "0",
  "platform": "W",
  "sigcap_model": "V",
  "register_version": "3062",
  "message_version": "03",
  "shift_number": "24456",
  "merchant_number": "0001",
  "store_number": "99999",
  "register_number": "001",
  "pos_capability": "0",
  "country_code": "USA",
  "currency_code": "USD",
  "timezone_differential": "-0600",
  "transaction_sequence_number": "2103",
  "card_id_source": "A",
  "account_entry_mode": "T",
  "encryption_indicator": "3",
  "magnetic_strip_info": "IALDuVMhfV7IB1GS/7fW4qbTNOoDaG9AFoLTuxDj14Nq5QeOwMjdksmMQknYMm+p8u5XNcnhGb+DEf179A0C3Hs2k8E+rlhkWBUB/a+i4Io1dGyNGjmuBEZsQRMMU9j0x6o3ycgqr1A5BmdP/FK3MMHu6OrQtOl3JVOEUC1r6gbM5XD1kOpiZWxY1TQgO5Ws9dUHczJmWEYeVXlaAJmnPKhw4Vm1aWKqf3xdm6Wbb/aqtuqgYeDNpMjsdgVKAy9RGyjgLSOEiIafQb39R+bb6jzqDvW9rQGbU7sfbv3ebX0PPmrodjDrvT7Ol6kwHQwi/gfnnS4ZNG+ccWwCk2l0dQ==",
  "flex_info": "PKI-KEY-ID=XXXXXXXXXXXX|PARTIAL-AUTH=N",
  "ancillary_verification": {
    "csc_indicator": "1",
    "account_holder": {
      "billing_postal_code": "75254",
      "billing_address": "123 Main Street"
    }
  },
  "e_commerce": {
    "e_commerce_indicator": "07",
    "order": {
      "invoice_number": "00035423563"
    }
  },
  "amount": "000000002550",
  "additional_amount": "0",
  "tender_attempt_indicator": "1",
  "unique_id_scheme": "S",
  "sender_unique_id": "BAB82200006"
}

Response / Status Code: 200
********************************************
{
  "store_number": "99999",
  "register_number": "001",
  "transaction_sequence_number": "2103",
  "response_code": "AD",
  "approval_code": "307348",
  "capture_date": "082219",
  "display_message": "APPROVAL        ",
  "flex_info": "APPROVED-AMOUNT=2550|EMV=ON",
  "response_status": {
    "incomm_id": "000003112886",
    "irc": "4001",
    "internal_description": "Duplicate approval"
  },
  "unique_id_scheme": "S",
  "sender_unique_id": "BAB82200006"
}
```
