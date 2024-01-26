export interface commonReturnResponse {
  isSuccessful: boolean;
  message: string;
  data: any;
}

export interface activityTypesResponse {
  id: number;
  activityName: string;
  buttonCss: string;
  isDisabled: boolean;
}

export interface activityResponse {
  activityId: string;
  activityTypeId: number;
  userDetails: string;
  activityName: string;
  activityStartedAt: Date;
  activityEndedAt?: Date;
  activityStatus: string;
}
