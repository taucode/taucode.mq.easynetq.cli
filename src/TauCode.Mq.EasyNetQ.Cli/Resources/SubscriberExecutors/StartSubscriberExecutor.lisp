(defblock :name start-subscriber :is-top t
	(executor
		:executor-name start-subscriber
		:verb "start"
		:description "Starts the subscriber."
		:usage-samples (
			"sub start"))

	(end)
)
