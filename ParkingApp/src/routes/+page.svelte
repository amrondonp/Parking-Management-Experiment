<script lang="ts">
	import {
		Table,
		TableBody,
		TableBodyCell,
		TableBodyRow,
		TableHead,
		TableHeadCell,
		P,
		Button,
		Input,
		Tooltip
	} from 'flowbite-svelte';
	import { CheckCircleSolid, CircleMinusSolid } from 'flowbite-svelte-icons';
	import { onMount } from 'svelte';
	import type { ParkingSession } from '../types/ParkingSession';
	import { writable, type Writable } from 'svelte/store';

	let parkingsMap: Writable<Map<number, ParkingSession>> = writable(new Map());
	let latestIdChanged: number | undefined = undefined;
	let plate: string | undefined = undefined;

	onMount(async () => {
		const response = await fetch('http://localhost:5068/ParkingSession?pageNumber=1&pageSize=20');
		const data: ParkingSession[] = await response.json();
		console.log(data);
		for (const parking of data) {
			parkingsMap.update((map) => {
				map.set(parking.id, parking);
				return map;
			});
		}
	});

	function dateToString(date: string | undefined | null): string {
		if (date === undefined || date === null) {
			return '';
		}

		return new Date(date).toLocaleString();
	}

	async function finishParking(id: number) {
		const response = await fetch(`http://localhost:5068/ParkingSession?parkingSessionId=${id}`, {
			method: 'PATCH'
		});
		const parking: ParkingSession = await response.json();

		parkingsMap.update((map) => {
			map.set(parking.id, parking);
			return map;
		});

		latestIdChanged = id;
	}

	async function createParking() {
		const response = await fetch(
			`http://localhost:5068/ParkingSession?plate=${plate}&ratePerMinute=52`,
			{ method: 'POST' }
		);
		const parking: ParkingSession = await response.json();

		parkingsMap.update((map) => {
			map.set(parking.id, parking);
			return map;
		});

		latestIdChanged = parking.id;

		// reset form
		plate = undefined;
	}

	function stopHighlighting() {
		latestIdChanged = undefined;
	}

	function formatMoney(amount: number, locale = 'es-CO', currency = 'COP') {
		return new Intl.NumberFormat(locale, {
			style: 'currency',
			currency,
			minimumFractionDigits: 0,
			maximumFractionDigits: 0
		}).format(amount);
	}
</script>

<div class="flex flex-col items-center justify-center gap-6 pl-[12px] pr-[12px] pt-[32px]">
	<P size="xl">Parking Alamos S.A.S</P>
	<form on:submit|preventDefault={createParking} class="flex flex-row gap-3">
		<Input id="name" bind:value={plate} placeholder="Ingrese placa" />
		<Button type="submit" color="primary">Enviar</Button>
	</form>

	<Table divClass="w-full">
		<TableHead>
			<TableHeadCell>Id</TableHeadCell>
			<TableHeadCell>Placa</TableHeadCell>
			<TableHeadCell>Entrada</TableHeadCell>
			<TableHeadCell>Salida</TableHeadCell>
			<TableHeadCell>$ / Minuto</TableHeadCell>
			<TableHeadCell>Minutos cobrados</TableHeadCell>
			<TableHeadCell>Sub total</TableHeadCell>
			<TableHeadCell>IVA</TableHeadCell>
			<TableHeadCell>Total</TableHeadCell>
			<TableHeadCell>Acción</TableHeadCell>
		</TableHead>
		<TableBody tableBodyClass="divide-y">
			{#each Array.from($parkingsMap.entries()).sort((a, b) => b[0] - a[0]) as [id, parking]}
				<TableBodyRow color={id === latestIdChanged ? 'green' : 'default'}>
					<TableBodyCell class="px-4 py-2">{parking.id}</TableBodyCell>
					<TableBodyCell class="px-4 py-2">{parking.plate}</TableBodyCell>
					<TableBodyCell class="px-4 py-2">{dateToString(parking.entryTime)}</TableBodyCell>
					<TableBodyCell class="px-4 py-2">{dateToString(parking.exitTime)}</TableBodyCell>
					<TableBodyCell class="px-4 py-2">{parking.ratePerMinute}</TableBodyCell>
					<TableBodyCell class="px-4 py-2">{parking.minutesCharged}</TableBodyCell>
					<TableBodyCell class="px-4 py-2">{formatMoney(parking.subtotal)}</TableBodyCell>
					<TableBodyCell class="px-4 py-2">{formatMoney(parking.taxes)}</TableBodyCell>
					<TableBodyCell class="px-4 py-2">{formatMoney(parking.total)}</TableBodyCell>
					<TableBodyCell class="px-4 py-2"
						>{#if !parking.exitTime}
							<Button color="light" on:click={() => finishParking(parking.id)}
								><CheckCircleSolid class="text-primary-700 dark:text-red-500" size="md" /></Button
							>
							<Tooltip>Terminar sesion de parqueo</Tooltip>
						{/if}
						{#if id === latestIdChanged}
							<Button color="light" on:click={() => stopHighlighting()}
								><CircleMinusSolid class="text-light-700 dark:text-red-500" size="md" /></Button
							>
							<Tooltip>Limpiar resaltado</Tooltip>
						{/if}
					</TableBodyCell>
				</TableBodyRow>
			{/each}
		</TableBody>
	</Table>
</div>
