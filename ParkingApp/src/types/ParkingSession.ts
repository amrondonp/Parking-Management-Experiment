export interface ParkingSession {
	id: number;
	plate: string;
	entryTime: string; // ISO string format from DateTimeOffset
	ratePerMinute: number;
	exitTime?: string | null; // nullable DateTimeOffset
	minutesCharged: number;
	subtotal: number;
	taxes: number;
	total: number;
}
