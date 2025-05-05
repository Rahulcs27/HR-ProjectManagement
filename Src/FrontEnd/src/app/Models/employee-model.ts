export class EmployeeModel {
}
export interface Employee {
  Image: string | null;
  Name: string;
  Code: string;
    designationName: string;
    branchName: string;
    divisionName: string;
    userGroupName: string;
    loginStatus: 'Active' | 'Inactive';
    action: string;
  }
  
  export interface EmployeeResponse {
    data: Employee[];
    totalCount: number;
    pageNumber: number;
    pageSize: number;
  }
  