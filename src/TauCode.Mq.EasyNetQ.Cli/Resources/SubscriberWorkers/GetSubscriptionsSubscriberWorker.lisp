(defblock :name get-subscriptions :is-top t
	(worker
		:worker-name get-subscriptions
		:verb "get"
		:description "Gets subscriptions of the subscriber."
		:usage-samples (
			"sub get"))

	(end)
)
