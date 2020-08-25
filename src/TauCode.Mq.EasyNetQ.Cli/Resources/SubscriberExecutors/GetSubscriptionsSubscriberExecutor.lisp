(defblock :name get-subscriptions :is-top t
	(executor
		:executor-name get-subscriptions
		:verb "get"
		:description "Gets subscriptions of the subscriber."
		:usage-samples (
			"sub get"))

	(end)
)
