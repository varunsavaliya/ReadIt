import { UserModel } from "./user.model";

export interface ResponseModel {
    success: boolean;
    message: string;
  }
  
  export interface ResponseDataModel<T> extends ResponseModel {
    data: T;
  }
  
  export interface ResponseListModel<T> extends ResponseModel {
    items: T[];
  }
  
  export interface AuthModel extends ResponseDataModel<UserModel>{
    token: string;
  }