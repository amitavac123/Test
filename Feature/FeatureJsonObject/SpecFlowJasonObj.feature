Feature: APIApplication


@Test1
Scenario: 22Get API respnse using given endpoint
    Given RestService "getemployees" with config in "ServiceDetailsJSONString" Json file
	Then I call "GET" service "getemployees" with modified parameter
	  | Veriable | Value  |   
	  | Version | 1       |
      | Cval    | Accept    |
	Given verify response should return "OK" as statuscode
	Then verify following response values
      | nodePath      | value    |
	  |  address.street |Kulas Light|
	  |  address.geo.lng |81.1496|
	  | name |Leanne Graham |
	  | website | hildegard.org  |

	  	  
	@Test2
Scenario: 22Post createuser API respnse using given endpoint
  Given RestService "createuser" with config in "ServiceDetailsJSONString" Json file
   Then I call "POST" service "createuser" with modified parameter
	  | Veriable | Value  |   
	 | contenttype | application/json       |
	Given verify response should return "OK" as statuscode
	Then verify following response values
      | nodePath      | value    |
      | name |morpheus|
	  | job | leader  |


	  @Test3
Scenario: 22 Get and Post API respnse using given endpoint
    Given RestService "getemployees" with config in "ServiceDetailsJSONString" Json file
	Then I call "GET" service "getemployees" with modified parameter
	  | Veriable | Value  |   
	  | Version | 1       |
      | Cval    | Accept    |
	Given verify response should return "OK" as statuscode
	Then verify following response values
      | nodePath      | value    |
	  |  address.street |Kulas Light|
	  |  address.geo.lng |81.1496|
	  | name |Leanne Graham |
	  | website | hildegard.org  |

  Given RestService "createuser" with config in "ServiceDetailsJSONString" Json file
   Then I call "POST" service "createuser" with modified parameter
	  | Veriable | Value  |   
	 | contenttype | application/json       |
	Given verify response should return "OK" as statuscode
	Then verify following response values
      | nodePath      | value    |
      | name |morpheus|
	  | job | leader  |
