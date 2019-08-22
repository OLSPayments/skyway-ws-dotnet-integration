# skyway-ws-dotnet-integration
.Net Example to interface with OLS.Payments Skyway Web Services sending a json payload:

Requires .NET Core - https://dotnet.microsoft.com/download

Remember to set proper URL and accessID and accessKey values in appsettings.json

Run in VSCode or Terminal:

Example run and output

```
$ dotnet run
Hello Skyway!

Sending Request to: https://hostname.domain.com:<port>/fsd/J.01-A

Request
********************************************
X-InComm-DateTime: 2019-08-22T07:02:54.681Z
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
  "pos_capability": "6",
  "country_code": "USA",
  "currency_code": "USD",
  "timezone_differential": "-0600",
  "encryption_indicator": "1",
  "transaction_sequence_number": "2103",
  "card_id_source": "A",
  "account_entry_mode": "T",
  "magnetic_strip_info": "4111111111111111",
  "amount": "000000001234",
  "additional_amount": "0",
  "tender_attempt_indicator": "1",
  "unique_id_scheme": "S",
  "sender_unique_id": "000000000000079454120278678665"
}

Response
********************************************
{
  "store_number": "99999",
  "register_number": "001",
  "transaction_sequence_number": "2103",
  "response_code": "NH",
  "approval_code": "000000",
  "capture_date": "000000",
  "display_message": "INVALID LOCATION",
  "response_status": {
    "irc": "2400",
    "internal_description": "Invalid merchant - Merchant with merchant-number required not found"
  },
  "unique_id_scheme": "S",
  "sender_unique_id": "000000000000079454120278678665"
}
```
