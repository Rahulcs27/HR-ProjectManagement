
export interface GetHolidayDto {
    holidayId: number;
    holidayName: string;
    holidayDate: string;
    holidayListType: boolean;
    year: number;
    status: boolean;
    dayName?: string;
    formattedDate?: string;
  }
  