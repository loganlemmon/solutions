<!DOCTYPE html>
<html>
<head>
	<title>Multisorting</title>
</head>
<body>

	<pre>
	<?php

	//Deliverables have both a delivery date and a rating

	class Deliverable {

		public $delivery_date;
		public $rating;

		public function __construct ($delivery_date, $rating){
			$this->delivery_date = $delivery_date;
			$this->rating = $rating;
		}
	}

	//our function accepts one parameter and stores the two array columns we're interested
	//in sorting by, then uses array_multisort to sort first by the delivery date column in 
	//ascending order, followed the rating column in descending.

	function sort_delivs($input){

		$days = array_column($input, 'delivery_date');
		$rating = array_column($input, 'rating');

		array_multisort($days, SORT_ASC, $rating, SORT_DESC, $input);

		return $input;
	}

	//to test, let's define a bunch of custom deliverables

	$deliv1 = new Deliverable(new DateTime('2019/04/25'), 3);
	$deliv2 = new Deliverable(new DateTime('2019/04/25'), 5);
	$deliv3 = new Deliverable(new DateTime('2019/05/10'), 2);
	$deliv4 = new Deliverable(new DateTime('2019/05/10'), 3);
	$deliv5 = new Deliverable(new DateTime('2019/06/19'), 5);
	$deliv6 = new Deliverable(new DateTime('2019/11/07'), 3);

	//and add them to an object

	$deliverables = [$deliv1, $deliv2, $deliv3, $deliv4, $deliv5, $deliv6];

	//and print out the results

	print_r(sort_delivs($deliverables));

	?>
</pre>

</body>
</html>
