import moment from 'moment';

export const singleDateFormat = (data: any, format: string = 'L') => {
    return data ? moment(data).format(format) : ''
}