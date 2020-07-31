Feature: APIApplication


@Test1
Scenario: 1Get API respnse using given endpoint
    Given RestService "getemployees" with config in "ServiceData" file
	And I call "GET" service with modified parameter
	  | Veriable | Value  |   
	  | Version | 1       |
      | Cval    | Accept    |
	And verify response should return "OK" as statuscode
	Then verify following response values
      | nodePath      | value    |
	  |  address.street |Kulas Light|
	  |  address.geo.lng |81.1496|
	  | name |Leanne Graham |
	  | website | hildegard.org  |
	  

@Test2
Scenario: 1Post createuser API respnse using given endpoint
  Given RestService "createuser" with config in "ServiceData" file
	And I call "POST" service with modified parameter
	  | Veriable | Value  |   
	 | contenttype | application/json       |
	And verify response should return "OK" as statuscode
	Then verify following response values
      | nodePath      | value    |
      | name |morpheus|
	  | job | leader  |
	
@Test3
 Scenario: 1Multiple API respnse using given endpoint
    Given RestService "getemployees" with config in "ServiceData" file
	And I call "GET" service with modified parameter
	  | Veriable | Value  |   
	  | Version | 1       |
      | Cval    | Accept    |
	And verify response should return "OK" as statuscode
	Then verify following response values
      | nodePath      | value    |
      | name |Leanne Graham |
	  | website | hildegard.org  |

    Given RestService "test1" with config in "ServiceData" file
	And I call "GET" service with modified parameter
       | Veriable | Value  |   
	  | contenttype | application/json       |
	   | Version | 1      |
	 And verify response should return "OK" as statuscode
      Then verify following response values
      | nodePath      | value    |
      | userId | 1 |
	  | id | 1 |
	  | title | delectus aut autem |
      | completed | False |

  Given RestService "employeetype" with config in "ServiceData" file
	And I call "GET" service with modified parameter
       | Veriable | Value  |   
	  | contenttype | application/json       |
	   | Version | 1      |
	 And verify response should return "OK" as statuscode
      Then verify following response values
      | nodePath      | value    |
      | userId | 1 |
	  | id | 1 |
	  | title | delectus aut autem |
      | completed | False |


	  @Test4
Scenario: 1Post and  Get API 1 using given endpoint
    Given RestService "createuser" with config in "ServiceData" file
	And I call "POST" service with modified parameter
	  | Veriable | Value  |   
	 | contenttype | application/json       |
	And verify response should return "OK" as statuscode
	Then verify following response values
      | nodePath      | value    |
      | name |morpheus|
	  | job | leader  |

 Given RestService "getemployees" with config in "ServiceData" file
	And I call "GET" service with modified parameter
	  | Veriable | Value  |   
	  | Version | 1       |
      | Cval    | Accept    |
	And verify response should return "OK" as statuscode
	Then verify following response values
      | nodePath      | value    |
      | name |Leanne Graham |
	  | website | hildegard.org  |

    Given RestService "test1" with config in "ServiceData" file
	And I call "GET" service with modified parameter
       | Veriable | Value  |   
	  | contenttype | application/json       |
	   | Version | 1      |
	 And verify response should return "OK" as statuscode
      Then verify following response values
      | nodePath      | value    |
      | userId | 1 |
	  | id | 1 |
	  | title | delectus aut autem |
      | completed | False |
	  
	  @Test5
Scenario: 1Both Get and Post API 2  using given endpoint
    Given RestService "createuser" with config in "ServiceData" file
	And I call "POST" service with modified parameter
	  | Veriable | Value  |   
	 | contenttype | application/json       |
	And verify response should return "OK" as statuscode
	Then verify following response values
      | nodePath      | value    |
      | name |morpheus|
	  | job | leader  |

    Given RestService "getemployees" with config in "ServiceData" file
	And I call "GET" service with modified parameter
	  | Veriable | Value  |   
	  | Version | 1       |
      | Cval    | Accept    |
	And verify response should return "OK" as statuscode
	Then verify following response values
      | nodePath      | value    |
      | name |Leanne Graham |
	  | website | hildegard.org  |